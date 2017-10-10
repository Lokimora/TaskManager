using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.MCS.Weeks;
using TaskRunner;

namespace TaskManager.Tasks
{
    public class WorkingDaysTask : ITask
    {
        private readonly IWeekService _weekService;

        public WorkingDaysTask(IWeekService weekService)
        {
            _weekService = weekService;
        }

        public void Run(object option)
        {


            _weekService.UpdateWorkingDays(2017);
        }
    }
}
