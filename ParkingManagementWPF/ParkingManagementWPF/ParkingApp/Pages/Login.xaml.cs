using _Repository;
using _Repository.Implements;
using _ViewModel.DTO;
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
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        private IUserRepository userRepository = new UserRepository();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            try
            {
                if (username.Equals(string.Empty) || password.Equals(string.Empty))
                {
                    throw new Exception("Input field must not empty!");
                }
                else
                {
                    UserDTO loggedUser = userRepository.Login(username, password);
                    MainWindow main = MainWindow.Instance;
                    main.LoggedUser = loggedUser;
                    main.Show();
                    txtUsername.Text = "";
                    txtPassword.Password = "";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
