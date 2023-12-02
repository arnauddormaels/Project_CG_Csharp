using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Exceptions
{
    public class ProductRepositoryException : Exception
    {
        public ProductRepositoryException(string? message) : base(message)
        {
        }

        public ProductRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
