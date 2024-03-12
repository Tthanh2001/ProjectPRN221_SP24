using _DataAccess.Models;
using _ViewModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.Mapper
{
    public static class MapToEntity
    {
        public static User? Map(UserDTO userDTO)
        {
            User? user = null;

            if (userDTO != null)
            {
                user = new User
                {
                    UserId = userDTO.UserId,
                    Email = userDTO.Email,
                    Username = userDTO.Username,
                    Password = userDTO.Password,
                    Phone = userDTO.Phone,
                    Address = userDTO.Address,
                    Role = userDTO.Role
                };

                foreach (VehicleDTO vehicleDTO in userDTO.Vehicles)
                {
                    user.Vehicles.Add(Map(vehicleDTO));
                }
            }

            return user;
        }

        public static Vehicle? Map(VehicleDTO vehicleDTO)
        {
            Vehicle? vehicle= null;

            if (vehicleDTO != null)
            {
                vehicle = new Vehicle
                {
                    VehicleCode = vehicleDTO.VehicleCode,
                    Brand = vehicleDTO.Brand,
                    Name = vehicleDTO.Name,
                    TypeId = vehicleDTO.TypeId,
                    IsParking = vehicleDTO.IsParking,
                    UserId = vehicleDTO.UserId
                };

                foreach (InvoiceDTO invoiceDto in vehicleDTO.Invoices)
                {
                    vehicle.Invoices.Add(Map(invoiceDto));
                }
            }

            return vehicle;
        }

        public static VehicleType? Map(VehicleTypeDTO vehicleTypeDTO)
        {
            VehicleType? vehicleType = null;

            if (vehicleTypeDTO != null)
            {
                vehicleType = new VehicleType
                {
                    TypeId = vehicleTypeDTO.TypeId,
                    PricePerHour = vehicleTypeDTO.PricePerHour,
                    PricePerDay = vehicleTypeDTO.PricePerDay,
                    PricePerMonth = vehicleTypeDTO.PricePerMonth,
                    PricePerWeek = vehicleTypeDTO.PricePerWeek,
                    PricePerYear = vehicleTypeDTO.PricePerYear,
                    Name = vehicleTypeDTO.Name
                };
            }
            return vehicleType;
        }

        public static Invoice? Map(InvoiceDTO invoiceDTO)
        {
            Invoice? invoice = null;

            if (invoiceDTO != null)
            {
                invoice = new Invoice
                {
                    InvoiceId = invoiceDTO.InvoiceId,
                    CheckInTime = invoiceDTO.CheckInTime,
                    CheckInOut = invoiceDTO.CheckInOut,
                    LotId = invoiceDTO.LotId,
                    VehicleCode = invoiceDTO.VehicleCode,
                    TotalPaid = invoiceDTO.TotalPaid
                };
            }

            return invoice;
        }

        public static Lot? Map(LotDTO lotDTO)
        {
            Lot? Lot = null;

            if (lotDTO != null)
            {
                Lot = new Lot
                {
                    LotId = lotDTO.LotArea+lotDTO.LotPosition,
                    Status = lotDTO.Status,
                    TypeId = lotDTO.TypeId
                };
            }

            return Lot;
        }
    }
}
