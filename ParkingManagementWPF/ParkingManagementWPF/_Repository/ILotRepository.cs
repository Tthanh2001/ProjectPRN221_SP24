using _ViewModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public interface ILotRepository
    {
        public IEnumerable<LotDTO> GetAll();
        public LotDTO GetById(string area, int position);
        public void UpdateStatus(string area, int position, bool status);
    }
}
