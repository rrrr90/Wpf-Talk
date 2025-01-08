using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_DB.Database;

namespace Wpf_Talk.Repositories
{
    public abstract class RepositoryBase
    {
        public MySqlDB GetMySqlDB()
        {
            return new MySqlDB(Properties.Resources.WPFDB_CONNECTION);
        }
    }
}
