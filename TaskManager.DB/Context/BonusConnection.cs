using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DB.Context
{
    public class BonusConnection : SqlBaseConnection
    {
        public BonusConnection(string bonusConnection) : base(bonusConnection)
        {
            
        }
    }
}
