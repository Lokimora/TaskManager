using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infrastructure
{
    public static class ContainerFactory
    {
        private static Container _container;

       

        public static void RegisterContainer()
        {
            _container = new Container();
            
        }

        public static Container GetContainer()
        {
            if(_container == null)
                RegisterContainer();

            return _container;

        }
    }
}
