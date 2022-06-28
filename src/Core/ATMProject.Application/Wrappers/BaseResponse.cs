using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Wrappers
{
    public class BaseResponse
    {

        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool success, string message)
        {

         
            Success = success;
            Message = message;
        }

 
        public BaseResponse( string message)
        {

          
            Message = message;
        }

        public BaseResponse()
        {

        }
    }

   
}
