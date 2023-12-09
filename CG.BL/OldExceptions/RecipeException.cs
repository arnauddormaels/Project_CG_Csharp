using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.OldExceptions
{
    public class RecipeException : Exception
    {

        public RecipeException(string? message) : base(message)
        {
        }

        public RecipeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
