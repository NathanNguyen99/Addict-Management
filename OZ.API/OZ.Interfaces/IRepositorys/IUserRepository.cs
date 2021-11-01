using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByID(Guid id);
        User Create(User domain);
        bool Update(User domain);
        bool Delete(Guid id);
        User CheckLogin(string username, string password);
        bool ChangePassword(Guid userid, string oldPassword, string newPassword);
    }
}
