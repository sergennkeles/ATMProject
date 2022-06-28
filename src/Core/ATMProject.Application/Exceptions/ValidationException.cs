using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Exceptions
{
    public  class ValidationException:Exception
    {
    

        public ValidationException():this("Validation Failed!")
        {

        }

        public ValidationException(string message):base(message)
        {

        }


        public ValidationException(Exception innerException):this(innerException.Message)
        {

        }

      
    }
}
