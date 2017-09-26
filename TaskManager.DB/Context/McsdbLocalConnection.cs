using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DB.Context
{
    public class McsdbLocalConnection : SqlBaseConnection
    {
        public McsdbLocalConnection(string mcsdbConnection) : base(mcsdbConnection)
        {
            
        }
    }
}
