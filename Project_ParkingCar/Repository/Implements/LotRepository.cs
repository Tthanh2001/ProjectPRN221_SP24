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
    public class LotRepository : ILotRepository
    {
        public IEnumerable<LotDTO> GetAll()
        {
            return LotDAO.Instance.GetAll().Select(m => MapToDTO.Map(m));
        }

        public LotDTO GetById(string area, int position)
        {
            return MapToDTO.Map(LotDAO.Instance.GetById(area+position));
        }

        public void UpdateStatus(string area, int position, bool status)
        {
            LotDAO.Instance.UpdateStatus(area+position, status);
        }
    }
}
