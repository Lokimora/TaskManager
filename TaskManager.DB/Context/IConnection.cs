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
        private IDbConnection _db;

        protected SqlBaseConnection(string connectionString)
        {
            _db = new SqlConnection(connectionString);

            //_db.Execute            
        }

        
    }
}
