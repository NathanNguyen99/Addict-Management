using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class UserService : IUserService
    {
        private IUserRepository repository;
        public UserService(IUserRepository userRepository)
        {
            repository = userRepository;
        }
        public User Create(User domain)
        {
            return repository.Create(domain);
        }
        public bool Update(User domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        public User GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public User CheckLogin(string username, string password)
        {
            return repository.CheckLogin(username, password);
        }

        public bool ChangePassword(Guid userid, string oldPassword, string newPassword)
        {
            return repository.ChangePassword(userid, oldPassword, newPassword);
        }
    }
}
