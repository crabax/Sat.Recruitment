using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application;
using Sat.Recruitment.Application.Contracts;
using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Application.Input;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result<UserDto>> CreateUser(CreateUserInput createUserInput)
        {
            var creationResult = await _userService.CreateUser(createUserInput);
            return creationResult;
        }

    }
}
