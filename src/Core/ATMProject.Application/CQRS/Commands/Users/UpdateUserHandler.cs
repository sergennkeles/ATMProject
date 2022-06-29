using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Customers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ServiceResponse<UpdateUserInfoDto>>
    {
        private readonly IAccountService _userService;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IAccountService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public  async Task<ServiceResponse<UpdateUserInfoDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
             var dto=_mapper.Map<UpdateUserInfoDto>(request);
            var result =  _userService.UpdateUserInfo(dto);
            return result;
              
        }
    }
}
