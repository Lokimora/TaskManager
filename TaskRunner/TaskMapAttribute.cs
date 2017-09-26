using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRunner
{
    public class TaskMapAttribute : Attribute
    {
        private Type _tasktype;

        public TaskMapAttribute(Type taskType)
        {
            if (!taskType.GetInterfaces().Contains(typeof(ITask)))
            {
                throw new ArgumentException("Type should implement ITask interface");
            }

            _tasktype = taskType;
        }

        public Type GetTaskType()
        {
            return _tasktype;            
        }
    }
}
