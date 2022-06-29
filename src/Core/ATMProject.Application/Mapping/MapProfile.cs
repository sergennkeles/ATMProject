using ATMProject.Application.CQRS.Commands.Customers;
using ATMProject.Application.DTOs;
using ATMProject.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Account, UserInfoDto>().ReverseMap();
            CreateMap<Account, UserInfoWithAccountDto>().ReverseMap();
            CreateMap<Account, UpdateUserCommand>().ReverseMap();
            CreateMap<UpdateUserInfoDto, UpdateUserCommand>().ReverseMap();
            CreateMap<Account, AccountInfoDto>().ReverseMap();
     
        }
    }
}
