using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DB.Commands.Update
{
    public class UpdateWorkingDayCommand : ICommand
    {       
        public string GetSqlCommand()
        {
            return "UPDATE RU.Week_Mst SET BASE_WD = @base_wd WHERE Id = @id";
        }
    }
}
