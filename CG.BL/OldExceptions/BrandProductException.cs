using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.OldExceptions
{
    public class BrandProductException : Exception
    {
        public BrandProductException(string? message) : base(message)
        {
        }

        public BrandProductException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
