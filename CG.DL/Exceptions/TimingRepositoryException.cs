using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Exceptions
{
    public class TimingRepositoryException : Exception
    {
        public TimingRepositoryException(string? message) : base(message)
        {

        }

        public TimingRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
