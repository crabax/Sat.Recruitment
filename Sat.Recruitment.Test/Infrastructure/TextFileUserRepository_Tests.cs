using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Infrastructure.Data;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sat.Recruitment.Test.Infrastructure
{
    public class TextFileUserRepository_Tests : IClassFixture<TestFixture>
    {
        private readonly TextFileUserRepository _textFileUserRepository;

        public TextFileUserRepository_Tests(TestFixture fixture)
        {
            _textFileUserRepository = (TextFileUserRepository)fixture.ServiceProvider.GetService<IUserRepository>();
        }

        [Fact]
        public void GetAllUsers_ReturnsUsers()
        {
            //arrange

            //act
            var users = _textFileUserRepository.GetAllUsers();

            //assert
            users.ShouldNotBeNull();
            users.Count.ShouldBeGreaterThan(0);
        }
    }
}
