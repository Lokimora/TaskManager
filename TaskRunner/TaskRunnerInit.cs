﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace TaskRunner
{
    public class TaskRunnerInit
    {
        private object _options;
        private readonly Container _container;


        public TaskRunnerInit(object options, Container container)
        {
            _options = options;
            _container = container;
        }

        public void Start()
        {
            var commands =
                _options.GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(Boolean) &&
                                (Boolean)p.GetValue(_options) == true &&
                                p.GetCustomAttributes<TaskMapAttribute>().Any()).ToArray();

            List<Task> tasks = new List<Task>();

            foreach (var v in commands)
            {
               
                TaskMapAttribute taskAttr = v.GetCustomAttribute<TaskMapAttribute>();

                var taskType = taskAttr?.GetTaskType();
                if (taskType != null)
                {
                    var ctor = taskType.GetConstructors()[0];
                    List<object> constructorParams = new List<object>();
                    foreach (var param in ctor.GetParameters())
                    {
                       var ctorParam = _container.GetInstance(param.ParameterType);
                        constructorParams.Add(ctorParam);
                    }


                    Task t = Task.Factory.StartNew(() =>
                    {
                        var taskInst = Activator.CreateInstance(taskType, BindingFlags.CreateInstance | BindingFlags.ExactBinding, constructorParams) as ITask;
                        taskInst?.Run(_options);

                    });

                    tasks.Add(t);
                }

            }
            Task.WaitAll(tasks.ToArray());
          
        }
    }
}
