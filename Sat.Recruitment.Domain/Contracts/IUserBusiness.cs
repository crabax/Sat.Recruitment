using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IUserBusiness
    {
        Task<User> CreateUser(User newUser);
    }
}
