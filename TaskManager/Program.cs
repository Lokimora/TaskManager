using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using TaskManager.Infrastructure;
using TaskManager.Tasks;
using TaskRunner;

namespace TaskManager
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Options options = new Options();

            if (args.Length > 0)
            {
                ContainerFactory.RegisterContainer();

                bool isValid = Parser.Default.ParseArguments(args, options);

                if (isValid)
                {
                    TaskRunnerInit init = new TaskRunnerInit(options);
                    init.Start();
                }
            }
        }
    }
}
