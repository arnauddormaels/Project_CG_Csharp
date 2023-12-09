using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.OldExceptions
{
    public class TimingException : Exception
    {
        public TimingException(string? message) : base(message)
        {
        }

        public TimingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
