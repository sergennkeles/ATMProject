﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.DTOs
{
    public class CustomerInfoWithAccountDto: BaseDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<AccountInfoDto> Accounts { get; set; }
    }
}
