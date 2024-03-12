using _DataAccess.DAO;
using _DataAccess.Models;
using _ViewModel.DTO;
using _ViewModel.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _Repository.Implements
{
    public class VehicleRepository : IVehicleRepository
    {
        public void AddVehicle(VehicleDTO vehicleDTO)
        {
            try
            {
                checkVehicleCode(vehicleDTO.VehicleCode);
                Vehicle vehicle = new Vehicle
                {
                    UserId = vehicleDTO.UserId,
                    VehicleCode = vehicleDTO.VehicleCode,
                    Brand = vehicleDTO.Brand,
                    IsParking = false,
                    TypeId = vehicleDTO.TypeId,
                    Name = vehicleDTO.Name,
                };
                VehicleDAO.Instance.Add(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteVehicle(string code)
        {
            VehicleDAO.Instance.Delete(code);
        }

        public IEnumerable<VehicleDTO> GetByUserId(int id)
        {
            return VehicleDAO.Instance.GetByUserId(id).Select(m => MapToDTO.Map(m));
        }

        public VehicleDTO GetByVehicleCode(string code)
        {
            return MapToDTO.Map(VehicleDAO.Instance.GetByVehicleCode(code));
        }

        public void UpdateisParking(string code, bool isParking)
        {
            VehicleDAO.Instance.UpdateIsParking(code, isParking);
        }

        private void checkVehicleCode(string code)
        {
            if (!Regex.Match(code, @"^(^[A-Z]{1}[0-9]{2}[ -][0-9]{4,6}$)").Success) throw new Exception("Vehicle code wrong! \nEx: A43-123456 or A43 123456");
        }
    }
}
