using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Data
{
    public class TextFileUserRepository : IUserRepository
    {
        private static readonly object fileLock = new object();

        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), Consts.FileRelativePath);

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            var lines = File.ReadAllLines(_filePath);
            foreach (var line in lines)
            {
                var user = new User
                {
                    Name = line.Split(Consts.Delimiter)[0].ToString(),
                    Email = line.Split(Consts.Delimiter)[1].ToString(),
                    Phone = line.Split(Consts.Delimiter)[2].ToString(),
                    Address = line.Split(Consts.Delimiter)[3].ToString(),
                    UserType = line.Split(Consts.Delimiter)[4].ToString(),
                    Money = decimal.Parse(line.Split(Consts.Delimiter)[5].ToString()),
                };
                users.Add(user);
            }
            return users;
        }

        public Task<User> CreateUser(User newUser)
        {
            var newLine = $"{Environment.NewLine}{newUser.Name}{Consts.Delimiter}{newUser.Email}{Consts.Delimiter}{newUser.Phone}{Consts.Delimiter}{newUser.Address}{Consts.Delimiter}{newUser.UserType}{Consts.Delimiter}{newUser.Money}";
            lock (fileLock)
            {
                File.AppendAllText(_filePath, newLine);
            }
            return Task.FromResult(newUser);
        }

        public Task<bool> UserAlreadyExists(User newUser)
        {
            var users = GetAllUsers();
            var userExists = users.Any(m =>
                (m.Email == newUser.Email || m.Phone == newUser.Phone)
                ||
                (m.Name == newUser.Name && m.Address == newUser.Address)
            );
            return Task.FromResult(userExists);
        }
    }
}
