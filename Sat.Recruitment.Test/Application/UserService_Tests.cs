using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Contracts;
using Sat.Recruitment.Application.Input;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.Application
{
    public class UserService_Tests : IClassFixture<TestFixture>
    {
        private readonly UserService _userService;

        public UserService_Tests(TestFixture fixture)
        {
            _userService = (UserService)fixture.ServiceProvider.GetService<IUserService>();
        }

        [Fact]
        public async Task CreateUser_ReturnsUserCreated()
        {
            //arrange
            var newUser = new CreateUserInput()
            {
                Name = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Email = $"{Guid.NewGuid()}@{Guid.NewGuid()}",
                Money = 1,
                Phone = Guid.NewGuid().ToString(),
                UserType = Guid.NewGuid().ToString()
            };

            //act
            var userCreatedResponse = await _userService.CreateUser(newUser);

            //assert
            userCreatedResponse.Data.ShouldNotBeNull();
            userCreatedResponse.Data.Name.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
