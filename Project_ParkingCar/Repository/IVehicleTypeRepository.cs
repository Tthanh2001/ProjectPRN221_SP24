using _ViewModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public interface IVehicleTypeRepository
    {
        public IEnumerable<VehicleTypeDTO> GetAll();
        public VehicleTypeDTO GetById(int id);
        public VehicleTypeDTO GetByName(string Name);
        public void Update(VehicleTypeDTO vehicleTypeDTO);

    }
}
