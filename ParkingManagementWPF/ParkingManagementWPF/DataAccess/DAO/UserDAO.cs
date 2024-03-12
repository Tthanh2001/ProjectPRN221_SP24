using _DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccess.DAO
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object iLock = new object();
        public UserDAO()
        {
        }

        public static UserDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public User GetById(int id)
        {
            User user = null;
            try
            {
                var db = new parkingDBWpfContext();
                user = db.Users.Include(c => c.Vehicles).ThenInclude(c => c.Type).SingleOrDefault(c => c.UserId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> user = null;
            try
            {
                var db = new parkingDBWpfContext();
                user = db.Users.Include(c => c.Vehicles).ThenInclude(c => c.Type).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public User GetByUsername(string username)
        {
            User user = null;
            try
            {
                var db = new parkingDBWpfContext();
                user = db.Users.Include(c => c.Vehicles).ThenInclude(c => c.Type).SingleOrDefault(c => c.Username.Equals(username));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public User GetByEmail(string email)
        {
            User user = null;
            try
            {
                var db = new parkingDBWpfContext();
                user = db.Users.Include(c => c.Vehicles).ThenInclude(c => c.Type).SingleOrDefault(c => c.Email.Equals(email));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            User user = null;
            try
            {
                var db = new parkingDBWpfContext();
                user = db.Users.Include(c => c.Vehicles).ThenInclude(c => c.Type).SingleOrDefault(c => c.Username.Equals(username) && c.Password.Equals(password));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public void Add(User user)
        {
            try
            {
                var db = new parkingDBWpfContext();
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(User user)
        {
            try
            {
                User _user = GetById(user.UserId);
                if (_user != null)
                {
                    _user.Phone = user.Phone;
                    _user.Address = user.Address;
                    var db = new parkingDBWpfContext();
                    db.Users.Update(_user);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find User");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
