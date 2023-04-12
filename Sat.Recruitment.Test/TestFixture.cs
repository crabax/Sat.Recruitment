using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sat.Recruitment.Application.Contracts;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Services;
using Sat.Recruitment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sat.Recruitment.Test
{
    public class TestFixture
    {
        private readonly IServiceProvider _serviceProvider;

        public TestFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<IUserRepository, TextFileUserRepository>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogger<UserService>, NullLogger<UserService>>(opt => NullLogger<UserService>.Instance);
            _serviceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider => _serviceProvider;
    }
}
