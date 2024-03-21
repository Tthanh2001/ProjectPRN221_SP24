using _DataAccess.Models;
using _ViewModel.DTO;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for AboutUs.xaml
    /// </summary>
    public partial class AboutUs : Page
    {
        private readonly parkingDBWpfContext _context;

        public AboutUs()
        {
            InitializeComponent();
            _context = new parkingDBWpfContext();
            LoadData();
        }
        public void LoadData()
        {
            var result = from user in this._context.Users
                         join vehicle in this._context.Vehicles
                         on user.UserId equals vehicle.UserId
                         join invoice in this._context.Invoices
                         on vehicle.VehicleCode equals invoice.VehicleCode
                         select new FilterDTO
                         {
                             UserId = user.UserId,
                             Username = user.Username,
                             VehicleCode = vehicle.VehicleCode,
                             CheckInTime = invoice.CheckInTime,
                             CheckInOut = invoice.CheckInOut,
                             TotalPaid = invoice.TotalPaid
                         };

            lvUser.ItemsSource = result.ToList();
            Total.Text = result.Sum(item => item.TotalPaid).ToString();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string searchName = sName.Text;
            var dateIn = dpDateIn.SelectedDate;
            var dateOut = dpDateOut.SelectedDate;

            var result = from user in this._context.Users
                         join vehicle in this._context.Vehicles
                         on user.UserId equals vehicle.UserId
                         join invoice in this._context.Invoices
                         on vehicle.VehicleCode equals invoice.VehicleCode
                         select new FilterDTO
                         {
                             UserId = user.UserId,
                             Username = user.Username,
                             VehicleCode = vehicle.VehicleCode,
                             CheckInTime = invoice.CheckInTime,
                             CheckInOut = invoice.CheckInOut,
                         };

            if (!string.IsNullOrEmpty(searchName))
            {
                result = result.Where(item => item.Username.Equals(searchName));
            }

            if (dateIn != null && dateOut != null)
            {
                result = result.Where(item => item.CheckInTime == dateIn && item.CheckInOut == dateOut);
            }

            lvUser.ItemsSource = result.ToList();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

