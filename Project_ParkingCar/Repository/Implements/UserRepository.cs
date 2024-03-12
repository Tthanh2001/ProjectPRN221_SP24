using _DataAccess.DAO;
using _DataAccess.Models;
using _Repository.Utils;
using _ViewModel.DTO;
using _ViewModel.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _Repository.Implements
{
    public class UserRepository : IUserRepository
    {
        public UserDTO FindByEmail(string email)
        {
            return MapToDTO.Map(UserDAO.Instance.GetByEmail(email));
        }

        public UserDTO FindByUsername(string username)
        {
            return MapToDTO.Map(UserDAO.Instance.GetByUsername(username));
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return UserDAO.Instance.GetAll().Select(m => MapToDTO.Map(m));
        }

        public UserDTO GetById(int id)
        {
            return MapToDTO.Map(UserDAO.Instance.GetById(id));
        }

        public UserDTO Login(string username, string password)
        {
            string pass = HashPassword.PasswordMD5Hash(password);
            try
            {
                UserDTO userDTO = MapToDTO.Map(UserDAO.Instance.GetByUsernameAndPassword(username, pass));
                if(userDTO==null) throw new Exception("Username or password is wrong! Try again!");
                return userDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void Register(string username, string password, string repassword, string email, string role)
        {
            try
            {
                if(UserDAO.Instance.GetByUsername(username)!=null) throw new Exception("Username is existed!");
                if (!password.Equals(repassword)) throw new Exception("Repassword does not match Password");

                checkMail(email);

                User user = new User
                {
                    Username = username,
                    Password = HashPassword.PasswordMD5Hash(password),
                    Email = email,
                    Role = role
                };
                UserDAO.Instance.Add(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(UserDTO userDTO)
        {
            try
            {
                checkMail(userDTO.Email);
                checkPhone(userDTO.Phone);

                User user = new User
                {
                    UserId = userDTO.UserId,
                    Email = userDTO.Email,
                    Address = userDTO.Address,
                    Phone = userDTO.Phone
                };
                UserDAO.Instance.Update(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void checkMail(string email)
        {
            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                throw new Exception("Wrong email format");
            }
        }

        private void checkPhone(string phone)
        {
            if(!Regex.Match(phone, @"^[0-9]{9,10}$").Success) throw new Exception("Wrong phone format! Must contain 9-10 digits");
        }
    }
}
