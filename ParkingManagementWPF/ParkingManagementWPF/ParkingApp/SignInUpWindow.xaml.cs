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
using System.Windows.Shapes;

namespace ParkingApp
{
    /// <summary>
    /// Interaction logic for SignInUpWindow.xaml
    /// </summary>
    public partial class SignInUpWindow : Window
    {
        public SignInUpWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Content = new Login();
        }

        private void btnLoginPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Login();
        }

        private void btnRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Register();
        }
    }
}
