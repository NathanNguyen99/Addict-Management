using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        { }

        public User Save(User domain)
        {
            try
            {
                var us = Create(domain);
                return us;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
        //public new Employee Create(Employee domain)
        //{
        //    Employee user = RepositoryContext.EmployeesDB.Where(x => x.Oid.Equals(id)).FirstOrDefault();
        //}
        public new bool Update(User domain)
        {
            try
            {
                //domain.Updated = DateTime.Now;
                base.Update(domain);
                return true;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                User user = RepositoryContext.AppUsers.Where(x => x.OID.Equals(id)).FirstOrDefault();
                if (user != null)
                {
                    Delete(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                return RepositoryContext.AppUsers.OrderBy(x => x.UserName);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public User GetByID(Guid id)
        {
            User user = RepositoryContext.AppUsers.Where(x => x.OID.Equals(id)).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public User CheckLogin(string username, string password)
        {
            User user = RepositoryContext.AppUsers.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool ChangePassword(Guid userid, string oldPassword, string newPassword)
        {
            try
            {
                User user = FindByCondition(x => x.OID.Equals(userid) && x.Password.Equals(oldPassword)).FirstOrDefault();
                if (user!=null)
                {
                    user.Password = newPassword;
                    base.Update(user);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;                
            }
        }
    }
}
