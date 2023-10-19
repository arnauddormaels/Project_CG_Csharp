using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Application.Exceptions
{

    public class ProductExeption : Exception
    {
        public ProductExeption(string? message) : base(message)
        {
        }

        public ProductExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
