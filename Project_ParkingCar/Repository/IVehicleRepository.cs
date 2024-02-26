using _ViewModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public interface IVehicleRepository
    {
        public VehicleDTO GetByVehicleCode(string code);
        public IEnumerable<VehicleDTO> GetByUserId(int id);
        public void AddVehicle(VehicleDTO vehicleDTO);
        public void DeleteVehicle(string code);
        public void UpdateisParking(string code, bool isParking);
    }
}
