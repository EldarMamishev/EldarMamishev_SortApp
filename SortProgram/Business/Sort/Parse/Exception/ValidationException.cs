using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sort.Parse.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationException(string message) : base(message)
        { }
    }
}
