using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Services;
using Sat.Recruitment.Infrastructure.Data;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.Domain
{
    public class UserBusiness_Tests : IClassFixture<TestFixture>
    {
        private readonly UserBusiness _userBusiness;

        public UserBusiness_Tests(TestFixture fixture)
        {
            _userBusiness = (UserBusiness)fixture.ServiceProvider.GetService<IUserBusiness>();
        }

        [Fact]
        public async Task CreateUser_ReturnsUserCreated()
        {
            //arrange
            var newUser = new User()
            {
                Name = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Email = $"{Guid.NewGuid()}@{Guid.NewGuid()}",
                Money = 1,
                Phone = Guid.NewGuid().ToString(),
                UserType = Guid.NewGuid().ToString()
            };

            //act
            var userCreated = await _userBusiness.CreateUser(newUser);

            //assert
            userCreated.ShouldNotBeNull();
            userCreated.Name.ShouldNotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task CreateUser_InvalidEmail_ReturnsException()
        {
            //arrange
            var newUser = new User()
            {
                Name = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Money = 1,
                Phone = Guid.NewGuid().ToString(),
                UserType = Guid.NewGuid().ToString()
            };

            //act
            async Task action()
            {
                await _userBusiness.CreateUser(newUser);
            }

            //assert
            await Assert.ThrowsAsync<ArgumentException>(action);
        }

        [Fact]
        public async Task CreateUser_ExistingUser_ReturnsException()
        {
            //arrange
            var newUser = new User()
            {
                Name = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Email = $"{Guid.NewGuid()}@{Guid.NewGuid()}",
                Money = 1,
                Phone = Guid.NewGuid().ToString(),
                UserType = Guid.NewGuid().ToString()
            };

            //act
            await _userBusiness.CreateUser(newUser);
            async Task action()
            {
                await _userBusiness.CreateUser(newUser);
            }

            //assert
            await Assert.ThrowsAsync<ArgumentException>(action);
        }

        [Theory]
        [InlineData(101)]
        [InlineData(11)]
        public async Task CreateUser_NormalGift_ReturnsUserCreated(decimal money)
        {
            //arrange
            var newUser = new User()
            {
                Name = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Email = $"{Guid.NewGuid()}@{Guid.NewGuid()}",
                Money = money,
                Phone = Guid.NewGuid().ToString(),
                UserType = "Normal"
            };

            //act
            var userCreated = await _userBusiness.CreateUser(newUser);

            //assert
            userCreated.ShouldNotBeNull();
            userCreated.Name.ShouldNotBeNullOrWhiteSpace();
        }

        [Theory]
        [InlineData(101)]
        public async Task CreateUser_SuperUserGift_ReturnsUserCreated(decimal money)
        {
            //arrange
            var newUser = new User()
            {
                Name = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Email = $"{Guid.NewGuid()}@{Guid.NewGuid()}",
                Money = money,
                Phone = Guid.NewGuid().ToString(),
                UserType = "SuperUser"
            };

            //act
            var userCreated = await _userBusiness.CreateUser(newUser);

            //assert
            userCreated.ShouldNotBeNull();
            userCreated.Name.ShouldNotBeNullOrWhiteSpace();
        }

        [Theory]
        [InlineData(101)]
        public async Task CreateUser_PremiumGift_ReturnsUserCreated(decimal money)
        {
            //arrange
            var newUser = new User()
            {
                Name = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Email = $"{Guid.NewGuid()}@{Guid.NewGuid()}",
                Money = money,
                Phone = Guid.NewGuid().ToString(),
                UserType = "Premium"
            };

            //act
            var userCreated = await _userBusiness.CreateUser(newUser);

            //assert
            userCreated.ShouldNotBeNull();
            userCreated.Name.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
