using _ViewModel.DTO;
using ParkingApp.Pages;
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

namespace ParkingApp
{
    public partial class MainWindow : Window
    {

        private static MainWindow instance = null;
        private static readonly object iLock = new object();

        public UserDTO LoggedUser { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public static MainWindow Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new MainWindow();
                    }
                    return instance;
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Content = new Default(LoggedUser);

            if (LoggedUser.Role.Equals("ADMIN"))
            {
                txtUserBtn.Text = "Management";
            }
        }

        private void btnUserInfo_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUser.Role.Equals("ADMIN"))
            {
                Main.Content = new UserInfoAdmin(LoggedUser.UserId);

            }
            else
            {
                Main.Content = new UserInfo(LoggedUser.UserId);

            }
        }

        private void btnlot_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ParkingLot(LoggedUser);
        }

        private void btnPricing_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUser.Role.Equals("ADMIN"))
            {
                Main.Content = new PricingAdmin();
            }
            else
            {
                Main.Content = new Pricing();
            }
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUser.Role.Equals("ADMIN"))
            {
                Main.Content = new AboutUs();
            }
            else
            {

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            instance = null;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
