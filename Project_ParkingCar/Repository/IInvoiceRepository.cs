using _ViewModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public interface IInvoiceRepository
    {
        public InvoiceDTO GetById(int id);
        public InvoiceDTO GetByParkingVehicleCode(string code);
        public void Add(InvoiceDTO invoiceDTO);
        public void Update(InvoiceDTO invoiceDTO);
    }
}
