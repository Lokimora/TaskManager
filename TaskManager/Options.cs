using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using TaskManager.Tasks;
using TaskManager.Tasks.Bonus;
using TaskRunner;

namespace TaskManager
{
    public class Options
    {
        #region

        [Option("CurrencyTask", HelpText = "Tasks that calculates working days includeing weekends and holiday",
            Required = false)]
        [TaskMap(typeof(CurrencyInformerTask))]
        public bool CurrencyTask { get; set; }

        [Option("WorkingDaysTask", HelpText = "test")]
        [TaskMap(typeof(WorkingDaysTask))]
        public bool WorkingDaysTask { get; set; }

        [Option("UpdatePoliciesTask", HelpText = "Update policies that have stage 5 and last update stage more then 30 days")]
        [TaskMap(typeof(UpdatePoliciesTask))]
        public bool UpdatePoliceiesWithStage5 { get; set; }

        #endregion


        #region arguments

        [Option("WorkingDaysYear", DefaultValue = 2017,
            HelpText = "Sets year that will be proceed for wokring days task")]
        public int WorkingDaysYear { get; set; }

        #endregion
    }
}
