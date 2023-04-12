using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Application.Dto
{
    public class UserDto
    {
        public string Name { get; }
        public string Email { get; }
        public string Address { get; }
        public string Phone { get; }
        public string UserType { get; }
        public decimal Money { get; }

        public UserDto(User userModel)
        {
            Name = userModel.Name;
            Email = userModel.Email;
            Address = userModel.Address;
            Phone = userModel.Phone;
            UserType = userModel.UserType;
            Money = userModel.Money;
        }
    }
}
