using _Repository;
using _Repository.Implements;
using _ViewModel.DTO;
using ParkingApp.WindowPage;
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
    /// Interaction logic for ParkingLot.xaml
    /// </summary>
    public partial class ParkingLot : Page
    {
        private UserDTO loggedUser = new UserDTO();
        private IVehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();

        public ParkingLot(UserDTO loggedUser)
        {
            InitializeComponent();

            this.loggedUser = loggedUser;
        }

        private void btnCarLotA_Click(object sender, RoutedEventArgs e)
        {
            if (loggedUser.Role.Equals("ADMIN"))
            {
                ParkingAreaDetailAdmin parkingAreaDetail = ParkingAreaDetailAdmin.Instance;
                parkingAreaDetail.Area = "A";
                parkingAreaDetail.Show();
            }
            else
            {
                ParkingAreaDetail parkingAreaDetail = ParkingAreaDetail.Instance;
                parkingAreaDetail.LoggedUser = loggedUser;
                parkingAreaDetail.Area = "A";
                parkingAreaDetail.AreaType = vehicleTypeRepository.GetByName("Car");
                parkingAreaDetail.Show();
            }
        }

        private void btnCarlotB_Click(object sender, RoutedEventArgs e)
        {
            if (loggedUser.Role.Equals("ADMIN"))
            {
                ParkingAreaDetailAdmin parkingAreaDetail = ParkingAreaDetailAdmin.Instance;
                parkingAreaDetail.Area = "B";
                parkingAreaDetail.Show();
            }
            else
            {
                ParkingAreaDetail parkingAreaDetail = ParkingAreaDetail.Instance;
                parkingAreaDetail.LoggedUser = loggedUser;
                parkingAreaDetail.Area = "B";
                parkingAreaDetail.AreaType = vehicleTypeRepository.GetByName("Car");
                parkingAreaDetail.Show();
            }
        }

        private void btnCarlotC_Click(object sender, RoutedEventArgs e)
        {
            if (loggedUser.Role.Equals("ADMIN"))
            {
                ParkingAreaDetailAdmin parkingAreaDetail = ParkingAreaDetailAdmin.Instance;
                parkingAreaDetail.Area = "C";
                parkingAreaDetail.Show();
            }
            else
            {
                ParkingAreaDetail parkingAreaDetail = ParkingAreaDetail.Instance;
                parkingAreaDetail.LoggedUser = loggedUser;
                parkingAreaDetail.Area = "C";
                parkingAreaDetail.AreaType = vehicleTypeRepository.GetByName("Car");
                parkingAreaDetail.Show();
            }
        }

        private void btnBusLotD_Click(object sender, RoutedEventArgs e)
        {
            if (loggedUser.Role.Equals("ADMIN"))
            {
                ParkingAreaDetailAdmin parkingAreaDetail = ParkingAreaDetailAdmin.Instance;
                parkingAreaDetail.Area = "D";
                parkingAreaDetail.Show();
            }
            else
            {
                ParkingAreaDetail parkingAreaDetail = ParkingAreaDetail.Instance;
                parkingAreaDetail.LoggedUser = loggedUser;
                parkingAreaDetail.Area = "D";
                parkingAreaDetail.AreaType = vehicleTypeRepository.GetByName("Bus");
                parkingAreaDetail.Show();
            }
        }

        private void btnTruckLotE_Click(object sender, RoutedEventArgs e)
        {
            if (loggedUser.Role.Equals("ADMIN"))
            {
                ParkingAreaDetailAdmin parkingAreaDetail = ParkingAreaDetailAdmin.Instance;
                parkingAreaDetail.Area = "E";
                parkingAreaDetail.Show();
            }
            else
            {
                ParkingAreaDetail parkingAreaDetail = ParkingAreaDetail.Instance;
                parkingAreaDetail.LoggedUser = loggedUser;
                parkingAreaDetail.Area = "E";
                parkingAreaDetail.AreaType = vehicleTypeRepository.GetByName("Truck");
                parkingAreaDetail.Show();
            }
        }
    }
}
