using ATMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Domain.Entities
{

    public  class Account:User
    {
     
  
        public decimal Cash { get; set; }

    }
}
