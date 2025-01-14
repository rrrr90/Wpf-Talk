using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Talk.Models;
using Wpf_DB.Database;

namespace Wpf_Talk.Repositories
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public long Insert(Account account)
        {
            string query =
                "insert into account(email, pwd, nickname, cell_phone)" +
                " values(@email, @pwd, @nickname, @cell_phone);";
            long lastId = -1;
            using MySqlDB db = GetMySqlDB();
            lastId = db.Execute(query, new SqlParameter[]
            {
                new SqlParameter(parameterName: "@email", account.Email),
                new SqlParameter(parameterName: "@pwd", account.Password),
                new SqlParameter(parameterName: "@nickname", account.Nickname),
                new SqlParameter(parameterName: "@cell_phone", account.CellPhone)
            });
            return lastId;
        }

        public long Update(Account account)
        {
            string query =
                "update account" +
                " set email=@email, pwd=@pwd, nickname=@nickname, cell_phone=@cell_phone" +
                " where id=@id";
            using MySqlDB db = GetMySqlDB();
            long updateId = -1;
            updateId = db.Execute(query, new SqlParameter[]
            {
                new SqlParameter(parameterName: "@id", account.ID),
                new SqlParameter(parameterName: "@email", account.Email),
                new SqlParameter(parameterName: "@pwd", account.Password),
                new SqlParameter(parameterName: "@nickname", account.Nickname),
                new SqlParameter(parameterName: "@cell_phone", account.CellPhone)
            });
            return updateId;
        }

        public void Delete(int id)
        {
            string query =
                "delete from account" +
                " where id=@id";
            using MySqlDB db = GetMySqlDB();
            db.Execute(query, new SqlParameter[]
            {
                new SqlParameter(parameterName: "@id", id)
            });
        }

        public Account[] GetAll()
        {
            string query =
                "select * from account"; // + " where id<@id";
            using MySqlDB db = GetMySqlDB();
            DataTable table = db.GetDataTable(query);
            List<Account> list = new List<Account>();
            foreach(DataRow row in table.Rows)
            {
                list.Add(ConvertToAccount(row));
            }
            return list.ToArray();
        }

        public int GetUid(Account account)
        {
            string query =
                "select id from account" +
                " where email=@email" +
                " and pwd=@pwd";
            using MySqlDB db = GetMySqlDB();
            DataTable table = db.GetDataTable(query, new SqlParameter[]
            {
                new SqlParameter(parameterName: "@email", value:account.Email),
                new SqlParameter(parameterName: "@pwd", value:account.Password)
            });
            foreach(DataRow row in table.Rows)
            {
                return (int)row["id"];
            }
            return -1;
        }

        public Account? GetAccount(int uid)
        {
            string query =
                "select * from account" +
                " where id=@id";
            using MySqlDB db = GetMySqlDB();
            DataTable table = db.GetDataTable(query, new SqlParameter[]
            {
                new SqlParameter(parameterName: "@id", value: uid)
            });
            if (table.Rows.Count == 0) return null;
            return ConvertToAccount(table.Rows[0]);
        }

        private Account ConvertToAccount(DataRow row)
        {
            return new Account()
            {
                ID = (int)row["id"],
                Email = (string)row["email"],
                Password = (string)row["pwd"],
                Nickname = (string)row["nickname"],
                CellPhone = (string)row["cell_phone"]
            };
        }
    }
}
