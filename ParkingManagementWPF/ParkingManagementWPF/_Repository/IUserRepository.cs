using _ViewModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public interface IUserRepository
    {
        public UserDTO Login(string username, string password);
        public void Register(string username, string password, string repassword, string email, string role);
        public IEnumerable<UserDTO> GetAll();
        public UserDTO GetById(int id);
        public UserDTO FindByUsername(string username);
        public UserDTO FindByEmail(string email);
        public void Update(UserDTO userDTO);
    }
}
