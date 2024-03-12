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
using System.Windows.Shapes;

namespace ParkingApp.WindowPage
{
    /// <summary>
    /// Interaction logic for ParkingAreaDetailAdmin.xaml
    /// </summary>
    public partial class ParkingAreaDetailAdmin : Window
    {
        private readonly ILotRepository lotRepository = new LotRepository();
        private readonly IVehicleRepository vehicleRepository = new VehicleRepository();
        private readonly IVehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();
        private readonly IInvoiceRepository invoiceRepository = new InvoiceRepository();

        private static ParkingAreaDetailAdmin instance = null;
        private static readonly object iLock = new object();

        public ParkingAreaDetailAdmin()
        {
            InitializeComponent();
        }

        public static ParkingAreaDetailAdmin Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new ParkingAreaDetailAdmin();
                    }
                    return instance;
                }
            }
        }

        public string Area { get; set; }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<LotDTO> lotList = lotRepository.GetAll().Where(c => c.LotArea.Equals(Area)).OrderBy(c => c.LotPosition).ToList();
            lvAreaLots.ItemsSource = new List<LotDTO>();
            lvAreaLots.ItemsSource = lotList;

            txtArea.Text = "Area " + Area;
        }

        private void lvAreaLots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LotDTO selectedLot = e.AddedItems[0] as LotDTO;
            lvInvoice.ItemsSource = selectedLot.Invoices.OrderByDescending(c => c.InvoiceId);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            instance = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            instance = null;
            this.Close();
        }
    }
}
