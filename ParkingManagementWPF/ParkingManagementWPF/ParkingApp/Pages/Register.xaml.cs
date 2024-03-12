using _Repository;
using _Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParkingApp.Pages
{
    public partial class Register : Page
    {

        private IUserRepository userRepository = new UserRepository();

        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string repassword = txtRePassword.Password;
            string email = txtEmail.Text;

            try
            {
                if (username.Equals(string.Empty) || password.Equals(string.Empty) || repassword.Equals(string.Empty) || email.Equals(string.Empty))
                {
                    throw new Exception("Input field must not empty!");
                }
                else
                {
                    userRepository.Register(username, password, repassword, email, "USER");
                    txtUsername.Text = "";
                    txtPassword.Password = "";
                    txtRePassword.Password = "";
                    txtEmail.Text = "";
                    MessageBox.Show("User register success! Go to login to use the app.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
