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
    /// Interaction logic for UserInfoAdmin.xaml
    /// </summary>
    public partial class UserInfoAdmin : Page
    {
        private readonly IUserRepository userRepository = new UserRepository();
        private readonly IVehicleRepository vehicleRepository = new VehicleRepository();
        private readonly IVehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();
        private int userid;
        private UserDTO user;

        public UserInfoAdmin(int userid)
        {
            InitializeComponent();
            this.userid = userid;
        }

        public void Load()
        {
            user = userRepository.GetById(userid);

            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone != null ? user.Phone : "";
            lvUser.ItemsSource = userRepository.GetAll().Where(c => c.Role.Equals("USER"));
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.Email = txtEmail.Text;
                user.Phone = txtPhone.Text;
                userRepository.Update(user);
                MessageBox.Show("Update information success");
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
