using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Exceptions
{
    internal class TimingMapperException : Exception
    {
        public TimingMapperException(string? message) : base(message)
        {
        }

        public TimingMapperException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
