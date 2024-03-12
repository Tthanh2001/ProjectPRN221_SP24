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
    public class InvoiceRepository : IInvoiceRepository
    {
        public void Add(InvoiceDTO invoiceDTO)
        {
            Invoice invoice = new Invoice
            {
                CheckInTime = invoiceDTO.CheckInTime,
                LotId = invoiceDTO.LotId,
                CheckInOut = invoiceDTO.CheckInOut,
                VehicleCode = invoiceDTO.VehicleCode,
                TotalPaid = 0
            };

            InvoiceDAO.Instance.Add(invoice);

        }

        public InvoiceDTO GetById(int id)
        {
            return MapToDTO.Map(InvoiceDAO.Instance.GetById(id));
        }

        public InvoiceDTO GetByParkingVehicleCode(string code)
        {
            return MapToDTO.Map(InvoiceDAO.Instance.GetByVehicleCode(code));
        }

        public void Update(InvoiceDTO invoiceDTO)
        {
            Invoice invoice = new Invoice
            {
                InvoiceId = invoiceDTO.InvoiceId,
                CheckInOut = invoiceDTO.CheckInOut,
                TotalPaid = invoiceDTO.TotalPaid
            };

            InvoiceDAO.Instance.Update(invoice);
        }
    }
}
