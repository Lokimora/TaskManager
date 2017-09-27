using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DB.Context
{
    public abstract class SqlBaseConnection
    {
        internal IDbConnection DB;

        protected SqlBaseConnection(string connectionString)
        {
            DB = new SqlConnection(connectionString);
         
        }

        
        
    }
}
