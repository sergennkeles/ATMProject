using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.DTOs
{
    public class AccountInfoDto: BaseDto
    {

        public int CustomerId { get; set; }
        public decimal  Cash { get; set; }
    }
}
