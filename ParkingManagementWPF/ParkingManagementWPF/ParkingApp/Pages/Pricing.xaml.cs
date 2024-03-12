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
    /// Interaction logic for Pricing.xaml
    /// </summary>
    public partial class Pricing : Page
    {
        private readonly IVehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();
        public Pricing()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            getContent(1, "CAR");
        }

        private void btnCarPrice_Click(object sender, RoutedEventArgs e)
        {

            getContent(1, "CAR");
        }

        private void btnBusPrice_Click(object sender, RoutedEventArgs e)
        {
            getContent(2, "BUS");
        }

        private void btnTruckPrice_Click(object sender, RoutedEventArgs e)
        {
            getContent(3, "TRUCK");
        }

        private void getContent(int id, string type)
        {
            VehicleTypeDTO vehicleTypeDTO = vehicleTypeRepository.GetById(id);
            txtPricingTitle.Text = type + " PRICING";
            txtHourPrice.Content = String.Format("{0:n0}", vehicleTypeDTO.PricePerHour) + " VNĐ";
            txtDayPrice.Content = String.Format("{0:n0}", vehicleTypeDTO.PricePerDay) + " VNĐ";
            txtWeekPrice.Content = String.Format("{0:n0}", vehicleTypeDTO.PricePerWeek) + " VNĐ";
            txtMonthPrice.Content = String.Format("{0:n0}", vehicleTypeDTO.PricePerMonth) + " VNĐ";
            txtYearPrice.Content = String.Format("{0:n0}", vehicleTypeDTO.PricePerYear) + " VNĐ";
        }
    }
}
