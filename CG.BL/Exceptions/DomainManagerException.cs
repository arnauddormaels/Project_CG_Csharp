using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Exceptions
{
    public class DomainManagerException : Exception
    {
        public DomainManagerException(string? message) : base(message)
        {
        }

        public DomainManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
