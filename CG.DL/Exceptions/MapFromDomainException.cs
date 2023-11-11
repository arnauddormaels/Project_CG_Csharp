using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Exceptions
{
    internal class MapFromDomainException : Exception
    {
        public MapFromDomainException(string? message) : base(message)
        {
        }

        public MapFromDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
