using _DataAccess.Models;
using _ViewModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.Mapper
{
    public static class MapToDTO
    {
        public static UserDTO? Map(User user)
        {
            UserDTO? userDTO = null;

            if (user != null)
            {
                userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password,
                    Phone = user.Phone,
                    Address = user.Address,
                    Role = user.Role
                };

                foreach (Vehicle vehicle in user.Vehicles)
                {
                    userDTO.Vehicles.Add(Map(vehicle));
                }
            }

            return userDTO;
        }

        public static VehicleDTO? Map(Vehicle vehicle)
        {
            VehicleDTO? vehicleDTO = null;

            if (vehicle != null)
            {
                vehicleDTO = new VehicleDTO
                {
                    VehicleCode = vehicle.VehicleCode,
                    Brand = vehicle.Brand,
                    Name = vehicle.Name,
                    TypeId = vehicle.TypeId,
                    TypeName = vehicle.Type.Name,
                    IsParking = vehicle.IsParking,
                    UserId = vehicle.UserId
                };

                foreach (Invoice invoice in vehicle.Invoices)
                {
                    vehicleDTO.Invoices.Add(Map(invoice));
                }
            }

            return vehicleDTO;
        }

        public static VehicleTypeDTO? Map(VehicleType vehicleType)
        {
            VehicleTypeDTO? vehicleTypeDTO = null;

            if (vehicleType != null)
            {
                vehicleTypeDTO = new VehicleTypeDTO
                {
                    TypeId = vehicleType.TypeId,
                    PricePerHour = vehicleType.PricePerHour,
                    PricePerDay = vehicleType.PricePerDay,
                    PricePerMonth = vehicleType.PricePerMonth,
                    PricePerWeek = vehicleType.PricePerWeek,
                    PricePerYear = vehicleType.PricePerYear,
                    Name = vehicleType.Name
                };

            }

            return vehicleTypeDTO;
        }

        public static InvoiceDTO? Map(Invoice invoice)
        {
            InvoiceDTO? invoiceDTO = null;

            if (invoice != null)
            {
                invoiceDTO = new InvoiceDTO
                {
                    InvoiceId = invoice.InvoiceId,
                    CheckInTime = invoice.CheckInTime,
                    CheckInOut = invoice.CheckInOut,
                    LotId = invoice.LotId,
                    VehicleCode = invoice.VehicleCode,
                    TotalPaid = invoice.TotalPaid
                };
            }

            return invoiceDTO;
        }

        public static LotDTO? Map(Lot lot)
        {
            LotDTO? LotDTO = null;

            if (lot != null)
            {
                string area = lot.LotId.Substring(0, 1);
                string position = lot.LotId.Substring(1);

                LotDTO = new LotDTO
                {
                    LotArea = area,
                    LotPosition = int.Parse(position),
                    Status = lot.Status,
                    TypeId = lot.TypeId,
                    isEmpty = (bool)lot.Status ? "Full" : "Empty",
                    ParkingVehicle = lot.Invoices.Count == 0 ? "" : (lot.Invoices.FirstOrDefault(c => c.CheckInOut==null)!=null ? lot.Invoices.FirstOrDefault(c => c.CheckInOut == null).VehicleCode:""),
                    Type = Map(lot.Type)
                };
                foreach (Invoice invoice in lot.Invoices)
                {
                    LotDTO.Invoices.Add(Map(invoice));
                }
            }

            return LotDTO;
        }
    }
}
