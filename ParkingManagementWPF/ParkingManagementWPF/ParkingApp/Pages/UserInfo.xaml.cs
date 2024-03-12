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
    public partial class UserInfo : Page
    {

        private readonly IUserRepository userRepository = new UserRepository();
        private readonly IVehicleRepository vehicleRepository = new VehicleRepository();
        private readonly IVehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();
        private int userid;
        private UserDTO user;

        public UserInfo(int userid)
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
            txtAddress.Text = user.Address != null ? user.Address : "";

            lvVehicles.ItemsSource = user.Vehicles;

            cmbType.ItemsSource = vehicleTypeRepository.GetAll();
            cmbType.SelectedIndex = 0;
            txtVehicleCode.Text = "";
            txtBrand.Text = "";
            txtName.Text = "";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.Email = txtEmail.Text;
                user.Phone = txtPhone.Text;
                user.Address = txtAddress.Text;
                userRepository.Update(user);
                MessageBox.Show("Update information success");
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNewVehicle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VehicleTypeDTO selectedType = cmbType.SelectedItem as VehicleTypeDTO;

                if (txtBrand.Text.Equals(string.Empty) || txtName.Equals(string.Empty))
                {
                    throw new Exception("Input field must not empty!");
                }
                else
                {
                    VehicleDTO newVehicle = new VehicleDTO
                    {
                        VehicleCode = txtVehicleCode.Text,
                        Brand = txtBrand.Text,
                        Name = txtName.Text,
                        UserId = user.UserId,
                        TypeId = selectedType.TypeId
                    };

                    vehicleRepository.AddVehicle(newVehicle);
                    MessageBox.Show("Add new vehicle success");
                    Load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
