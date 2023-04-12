using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private void AddGiftIfApplicable(ref User newUser)
        {
            var percentage = 0m;

            if (newUser.UserType == Consts.UserTypeNormal)
            {
                if (newUser.Money > 100)
                {
                    percentage = Convert.ToDecimal(0.12);
                }
                else if (newUser.Money > 10)
                {
                    percentage = Convert.ToDecimal(0.8);
                }
            }

            if (newUser.UserType == Consts.UserTypeSuperUser && newUser.Money > 100)
            {
                percentage = Convert.ToDecimal(0.20);
            }

            if (newUser.UserType == Consts.UserTypePremium && newUser.Money > 100)
            {
                percentage = 2;
            }

            var gift = newUser.Money * percentage;
            newUser.Money += gift;
        }

        private void NormalizeEmail(ref User newUser)
        {
            try
            {
                var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
                aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
                newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });
            }
            catch (Exception)
            {
                throw new ArgumentException(Consts.Error_EmailNormalization);
            }
        }

        public async Task<User> CreateUser(User newUser)
        {
            var userAlreadyExists = await _userRepository.UserAlreadyExists(newUser);
            if (userAlreadyExists)
            {
                throw new ArgumentException(Consts.Error_UserDuplicated);
            }

            NormalizeEmail(ref newUser);
            AddGiftIfApplicable(ref newUser);
            return await _userRepository.CreateUser(newUser);
        }
    }
}
