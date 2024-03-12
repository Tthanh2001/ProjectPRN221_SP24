using _Repository;
using _Repository.Implements;
using _Repository.Utils;
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
    public partial class ParkingAreaDetail : Window
    {
        private readonly ILotRepository lotRepository = new LotRepository();
        private readonly IVehicleRepository vehicleRepository = new VehicleRepository();
        private readonly IVehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();
        private readonly IInvoiceRepository invoiceRepository = new InvoiceRepository();

        private static ParkingAreaDetail instance = null;
        private static readonly object iLock = new object();

        public ParkingAreaDetail()
        {
            InitializeComponent();
        }

        public static ParkingAreaDetail Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new ParkingAreaDetail();
                    }
                    return instance;
                }
            }
        }

        public string Area { get; set; }
        public UserDTO LoggedUser { get; set; }
        public VehicleTypeDTO AreaType { get; set; }

        private LotDTO selectedLot;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<LotDTO> lotList = lotRepository.GetAll().Where(c => c.LotArea.Equals(Area)).OrderBy(c => c.LotPosition).ToList();
            lvAreaLots.ItemsSource = new List<LotDTO>();
            lvAreaLots.ItemsSource = lotList;

            CmbVehicleViewAll(AreaType);
            
            txtArea.Text = "Area " + Area;
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            instance = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvAreaLots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedLot = e.AddedItems[0] as LotDTO;
                

                if (selectedLot.Status == false)
                {
                    txtPositon.Text = selectedLot.LotPosition.ToString();

                    btnPark.Content = "Park here";

                    txtCheckInTime.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    txtCurrentTime.Text = "";
                    txtPaid.Text = "";

                    CmbVehicleViewAll(AreaType);
                }
                else
                {
                    if(LoggedUser.Vehicles.FirstOrDefault(c => c.VehicleCode.Equals(selectedLot.ParkingVehicle)) != null)
                    {
                        txtPositon.Text = selectedLot.LotPosition.ToString();
                        btnPark.Content = "Leave";

                        InvoiceDTO invoiceDTO = invoiceRepository.GetByParkingVehicleCode(selectedLot.ParkingVehicle);

                        txtInvoiceId.Text = invoiceDTO.InvoiceId.ToString();
                        txtCheckInTime.Text = invoiceDTO.CheckInTime.ToString();
                        txtCurrentTime.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                        txtPaid.Text = String.Format("{0:n0}", calculateTotalPaid(invoiceDTO.CheckInTime, DateTime.Parse(txtCurrentTime.Text))) +" VNĐ";

                        CmbVehicleViewParked(AreaType, selectedLot.ParkingVehicle);
                        cmbVehicle.IsEnabled = false;
                    }
                    else
                    {
                        throw new Exception("This is not your vehicle :) !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPark_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VehicleDTO vehicle = cmbVehicle.SelectedItem as VehicleDTO;

                if (btnPark.Content.Equals("Park here"))
                {
                    InvoiceDTO newInvoice = new InvoiceDTO
                    {
                        CheckInTime = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")),
                        LotId = Area + selectedLot.LotPosition,
                        VehicleCode = vehicle.VehicleCode,
                        TotalPaid = 0
                    };
                    vehicleRepository.UpdateisParking(vehicle.VehicleCode, true);
                    lotRepository.UpdateStatus(Area, selectedLot.LotPosition, true);
                    invoiceRepository.Add(newInvoice);

                    
                    MessageBox.Show("Complete parking!");
                }
                else
                {
                    InvoiceDTO lotInvoice = invoiceRepository.GetById(int.Parse(txtInvoiceId.Text));
                    lotInvoice.CheckInOut = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    lotInvoice.TotalPaid = calculateTotalPaid(lotInvoice.CheckInTime, lotInvoice.CheckInOut);

                    invoiceRepository.Update(lotInvoice);
                    vehicleRepository.UpdateisParking(lotInvoice.VehicleCode, false);
                    lotRepository.UpdateStatus(Area, selectedLot.LotPosition, false);
                    

                    MessageBox.Show("Leaving success! \nThank you for using our service!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                instance = null;
                this.Close();
            }
        }

        private void CmbVehicleViewAll(VehicleTypeDTO AreaType)
        {
            List<VehicleDTO> vehicles = vehicleRepository.GetByUserId(LoggedUser.UserId).Where(c => c.IsParking == false && c.TypeId == AreaType.TypeId).ToList();
            if (vehicles.Count == 0)
            {
                cmbVehicle.ItemsSource = new List<VehicleDTO>();
                cmbVehicle.IsEnabled = false;
                btnPark.IsEnabled = false;
            }
            else
            {
                cmbVehicle.ItemsSource = vehicles;
                cmbVehicle.SelectedIndex = 0;
                cmbVehicle.IsEnabled = true;
                btnPark.IsEnabled = true;
            }
        }

        private void CmbVehicleViewParked(VehicleTypeDTO AreaType, string code)
        {
            List<VehicleDTO> vehicles = vehicleRepository.GetByUserId(LoggedUser.UserId).Where(c => c.VehicleCode.Equals(code)).ToList();
            if (vehicles.Count == 0)
            {
                cmbVehicle.ItemsSource = new List<VehicleDTO>();
                cmbVehicle.IsEnabled = false;
                btnPark.IsEnabled = false;
            }
            else
            {
                cmbVehicle.ItemsSource = vehicles;
                cmbVehicle.SelectedIndex = 0;
                cmbVehicle.IsEnabled = true;
                btnPark.IsEnabled = true;
            }
        }

        private void LoadLotView()
        {
            try
            {
                List<LotDTO> lotList = lotRepository.GetAll().Where(c => c.LotArea.Equals(Area)).OrderBy(c => c.LotPosition).ToList();
                lvAreaLots.ItemsSource = lotList;
            }
            catch (Exception ex)
            {
                throw new Exception("hehe");
            }
        }

        private decimal calculateTotalPaid(DateTime? checkIn, DateTime? checkOut)
        {
            int[] parkingTime = Calculate.CalculateParkingTime(checkIn, checkOut);
            return parkingTime[0] * AreaType.PricePerHour
                            + parkingTime[1] * AreaType.PricePerDay
                            + parkingTime[2] * AreaType.PricePerWeek
                            + parkingTime[3] * AreaType.PricePerMonth
                            + parkingTime[4] * AreaType.PricePerYear;
        }
    }
}
