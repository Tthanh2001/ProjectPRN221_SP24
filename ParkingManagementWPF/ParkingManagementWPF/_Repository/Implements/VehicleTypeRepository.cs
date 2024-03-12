using _DataAccess.DAO;
using _DataAccess.Models;
using _ViewModel.DTO;
using _ViewModel.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository.Implements
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        public IEnumerable<VehicleTypeDTO> GetAll()
        {
            return VehicleTypeDAO.Instance.GetAll().Select(m => MapToDTO.Map(m));
        }

        public VehicleTypeDTO GetById(int id)
        {
            return MapToDTO.Map(VehicleTypeDAO.Instance.GetById(id));
        }

        public VehicleTypeDTO GetByName(string Name)
        {
            return MapToDTO.Map(VehicleTypeDAO.Instance.GetByName(Name));
        }

        public void Update(VehicleTypeDTO vehicleTypeDTO)
        {
            VehicleType type = new VehicleType
            {
                TypeId = vehicleTypeDTO.TypeId,
                PricePerHour = vehicleTypeDTO.PricePerHour,
                PricePerDay = vehicleTypeDTO.PricePerDay,
                PricePerWeek = vehicleTypeDTO.PricePerWeek,
                PricePerMonth = vehicleTypeDTO.PricePerMonth,
                PricePerYear = vehicleTypeDTO.PricePerYear
            };
            VehicleTypeDAO.Instance.Update(type);
        }
    }
}
