using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Contracts;
using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Application.Input;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sat.Recruitment.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly ILogger _logger;

        public UserService(IUserBusiness userBusiness, ILogger<UserService> logger) 
        {
            _userBusiness = userBusiness;
            _logger = logger;
        }

        public async Task<Result<UserDto>> CreateUser(CreateUserInput createUserInput)
        {
            try
            {
                var user = new User
                {
                    Name = createUserInput.Name,
                    Email = createUserInput.Email,
                    Address = createUserInput.Address,
                    Phone = createUserInput.Phone,
                    UserType = createUserInput.UserType,
                    Money = createUserInput.Money
                };

                var userCreated = await _userBusiness.CreateUser(user);
                var userDto = new UserDto(userCreated);
                return Result.Success(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(UserService.CreateUser));
                return Result.Fail<UserDto>(ex.Message);
            }
        }
    }
}
