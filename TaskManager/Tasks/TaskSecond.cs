using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskRunner;

namespace TaskManager.Tasks
{
    public class WorkingDaysTask : ITask
    {
        public void Run(object option)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Second Task: {i}");
            }
        }
    }
}
