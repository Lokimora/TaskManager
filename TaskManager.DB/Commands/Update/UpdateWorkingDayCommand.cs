using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DB.Commands.Update
{
    public class UpdateWorkingDayCommand : ICommand
    {        
        /// <summary>
        /// update week_mst
        /// </summary>
        /// <param name="id">id of entity</param>
        /// <param name="base_wd">working day number</param>
        /// <returns></returns>
        public string GetSqlCommand(int id, int base_wd)
        {
            return _command;
        }
    }
}
