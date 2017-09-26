using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskRunner
{
    public class TaskRunnerInit
    {
        private object _options;
        


        public TaskRunnerInit(object options)
        {
            _options = options;
        }

        public void Start()
        {
            var commands =
                _options.GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(Boolean) &&
                        p.GetCustomAttributes<TaskMapAttribute>().Any()).ToArray();

            List<Task> tasks = new List<Task>();

            foreach (var v in commands)
            {
                TaskMapAttribute taskAttr = v.GetCustomAttribute<TaskMapAttribute>();

                var taskType = taskAttr?.GetTaskType();
                if (taskType != null)
                {

                    Task t = Task.Factory.StartNew(() =>
                    {
                        var taskInst = Activator.CreateInstance(taskType) as ITask;
                        taskInst?.Run(_options);

                    });

                    tasks.Add(t);
                }

            }
            Task.WaitAll(tasks.ToArray());
          
        }
    }
}
