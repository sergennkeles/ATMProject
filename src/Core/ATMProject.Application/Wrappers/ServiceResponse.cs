using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Wrappers
{
    public class ServiceResponse<T>:BaseResponse
    {
        public T Data { get; set; }
        public ServiceResponse(T data, bool success, string message):base(success, message)
        {
            Data = data;
        }

        public ServiceResponse(T data)
        {
            Data = data;
        }

        public ServiceResponse(string message):base(message)
        {
          
        }
        public ServiceResponse()
        {

        }
    }
}
