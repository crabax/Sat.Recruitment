using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Application.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Contracts
{
    public interface IUserService
    {
        Task<Result<UserDto>> CreateUser(CreateUserInput createUserInput);
    }
}
