using ATMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Domain.Entities
{
    public  class Account:BaseEntity
    {
     
        public int CustomerId { get; set; }
        public decimal Cash { get; set; }

        public Customer Customer { get; set; }
    }
}
