using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_DB.Database;
using Wpf_Talk.Models;

namespace Wpf_Talk.Repositories
{
    public class ChattingRepository : RepositoryBase, IChattingRepository
    {
        public ChattingListItem[] GetLastChattings(int myUid)
        {
            string query =
                "select * from chatting" +
                " where sender=@id1 and recver=@id2 or sender=@id2 and recver=@id1" +
                " order by id desc limit 1";
            using MySqlDB db = GetMySqlDB();

            Account[] accounts = GetFriends(myUid);

            List<ChattingListItem> chattings = new List<ChattingListItem>();
            foreach (int opUid in accounts.Select(x => x.ID))
            {
                var table = db.GetDataTable(query, new SqlParameter[] {
                    new SqlParameter(parameterName: "@id1", myUid),
                    new SqlParameter(parameterName: "@id2", opUid)
                });
                if (table.Rows.Count > 0)
                {
                    string message = (string)table.Rows[0]["message"];
                    message = message.Length > 26 ? message[..24].Trim() + "..." : message;
                    DateTime sendDate = (DateTime)table.Rows[0]["send_date"];
                    string lasttime = sendDate.ToLongDateString() == DateTime.Now.ToLongDateString()
                        ? sendDate.ToShortTimeString() : sendDate.ToShortDateString();
                    chattings.Add(new ChattingListItem()
                    {
                        Name = Array.Find(accounts, x => x.ID == opUid)?.Nickname ?? "null",
                        Message = message,
                        LastTime = lasttime
                    });
                }
            }

            // TODO: ID 리스트 가져오기
            return chattings.ToArray();
        }

        public ChattingItem[] GetChattings(int myUid, int opUid)
        {
            string query =
                "select * from chatting" +
                " where sender=@id1 and recver=@id2 or sender=@id2 and recver=@id1" +
                " order by id asc";

            using MySqlDB db = GetMySqlDB();
            DataTable table = db.GetDataTable(query, new SqlParameter[]
            {
                new SqlParameter(parameterName: "@id1", value: myUid),
                new SqlParameter(parameterName: "@id2", value: opUid)
            });

            List<ChattingItem> list = new List<ChattingItem>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new ChattingItem()
                {
                    Sender = (int)row["sender"],
                    Recver = (int)row["recver"],
                    Message = (string)row["message"],
                    SendDate = ((DateTime)row["send_date"]).ToString()
                });
            }

            return list.ToArray();
        }

        private Account[] GetFriends(int myUid)
        {
            string query =
                "select * from account";

            using MySqlDB db = GetMySqlDB();
            DataTable usersTable = db.GetDataTable(query);

            List<Account> accounts = new List<Account>();
            foreach (DataRow row in usersTable.Rows)
            {
                if ((int)row["id"] == myUid) continue;

                accounts.Add(new Account()
                {
                    ID = (int)row["id"],
                    Nickname = (string)row["Nickname"]
                });
            }
            return accounts.ToArray();
        }


        public bool SendMessage(int sender, int recver, string message)
        {
            string query =
                "insert into chatting(sender, recver, message)" +
                " values(@sender, @recver, @message)";

            using MySqlDB db = GetMySqlDB();
            long lastId = db.Execute(query, new SqlParameter[]
            {
                new SqlParameter(parameterName: "@sender", value: sender),
                new SqlParameter(parameterName: "@recver", value: recver),
                new SqlParameter(parameterName: "@message", value: message)
            });
            return lastId >= 0;
        }
    }
}
