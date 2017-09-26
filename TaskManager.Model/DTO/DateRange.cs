using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model.DTO
{
    public class DateRange
    {
        private readonly DateTime _leftInterval;
        private readonly DateTime _rightInterval;

        public DateRange(DateTime leftInterval, DateTime rightInterval)
        {
            _leftInterval = leftInterval;
            _rightInterval = rightInterval;
        }

        private DateRange()
        {

        }

        public DateTime LeftInterval { get { return _leftInterval; } }
        public DateTime RightInterval { get { return _rightInterval; } }
    }
}
