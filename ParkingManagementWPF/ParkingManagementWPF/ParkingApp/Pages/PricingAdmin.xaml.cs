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
    /// Interaction logic for PricingAdmin.xaml
    /// </summary>
    public partial class PricingAdmin : Page
    {
        private readonly IVehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();

        private VehicleTypeDTO selectedType;

        public PricingAdmin()
        {
            InitializeComponent();
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            getContent(1);
        }

        private void btnCarPrice_Click(object sender, RoutedEventArgs e)
        {
            getContent(1);
        }

        private void btnBusPrice_Click(object sender, RoutedEventArgs e)
        {
            getContent(2);
        }

        private void btnTruckPrice_Click(object sender, RoutedEventArgs e)
        {
            getContent(3);
        }

        private void getContent(int id)
        {
            selectedType = vehicleTypeRepository.GetById(id);
            txtPricingTitle.Text = selectedType.Name.ToUpper() + " PRICING";
            txtHourPrice.Text = String.Format("{0:n0}", selectedType.PricePerHour);
            txtDayPrice.Text = String.Format("{0:n0}", selectedType.PricePerDay);
            txtWeekPrice.Text = String.Format("{0:n0}", selectedType.PricePerWeek);
            txtMonthPrice.Text = String.Format("{0:n0}", selectedType.PricePerMonth);
            txtYearPrice.Text = String.Format("{0:n0}", selectedType.PricePerYear);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtHourPrice.Text.Equals(string.Empty) || txtDayPrice.Equals(string.Empty) || txtWeekPrice.Equals(string.Empty) || txtMonthPrice.Equals(string.Empty) || txtYearPrice.Equals(string.Empty))
                {
                    throw new Exception("Input field must not empty!");
                }
                else
                {
                    selectedType.PricePerHour = decimal.Parse(txtHourPrice.Text);
                    selectedType.PricePerDay = decimal.Parse(txtDayPrice.Text);
                    selectedType.PricePerWeek = decimal.Parse(txtWeekPrice.Text);
                    selectedType.PricePerMonth = decimal.Parse(txtMonthPrice.Text);
                    selectedType.PricePerYear = decimal.Parse(txtYearPrice.Text);

                    vehicleTypeRepository.Update(selectedType);

                    MessageBox.Show("Update complete");
                    getContent(selectedType.TypeId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
