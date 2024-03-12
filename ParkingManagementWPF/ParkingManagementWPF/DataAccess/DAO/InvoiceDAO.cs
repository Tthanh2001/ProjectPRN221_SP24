using _DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccess.DAO
{
    public class InvoiceDAO
    {
        private static InvoiceDAO instance = null;
        private static readonly object iLock = new object();
        public InvoiceDAO()
        {
        }

        public static InvoiceDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new InvoiceDAO();
                    }
                    return instance;
                }
            }
        }

        public Invoice GetById(int id)
        {
            Invoice invoice = null;
            try
            {
                var db = new parkingDBWpfContext();
                invoice = db.Invoices.SingleOrDefault(c => c.InvoiceId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return invoice;
        }

        public Invoice GetByVehicleCode(string code)
        {
            Invoice invoice = null;
            try
            {
                var db = new parkingDBWpfContext();
                invoice = db.Invoices.SingleOrDefault(c => c.VehicleCode.Equals(code) && c.CheckInOut==null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return invoice;
        }

        public void Add(Invoice invoice)
        {
            try
            {
                var db = new parkingDBWpfContext();
                db.Invoices.Add(invoice);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Invoice invoice)
        {
            try
            {
                var db = new parkingDBWpfContext();
                Invoice _invoice = db.Invoices.SingleOrDefault(c => c.InvoiceId == invoice.InvoiceId);
                if (_invoice != null)
                {
                    _invoice.CheckInOut = invoice.CheckInOut;
                    _invoice.TotalPaid = invoice.TotalPaid;
                    

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find invoice");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
