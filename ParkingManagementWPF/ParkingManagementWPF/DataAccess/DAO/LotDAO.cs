using _DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccess.DAO
{
    public class LotDAO
    {
        private static LotDAO instance = null;
        private static readonly object iLock = new object();
        public LotDAO()
        {
        }

        public static LotDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new LotDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Lot> GetAll()
        {
            List<Lot> lots;
            try
            {
                var db = new parkingDBWpfContext();
                lots = db.Lots.Include(c => c.Invoices).Include(c => c.Type).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lots;
        }

        public Lot GetById(string id)
        {
            Lot lot = null;
            try
            {
                var db = new parkingDBWpfContext();
                lot = db.Lots.Include(c => c.Type).Include(c => c.Invoices).SingleOrDefault(c => c.LotId.Equals(id));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lot;
        }

        public void UpdateStatus(string id, bool status)
        {
            try
            {
                Lot _lot = GetById(id);
                if (_lot != null)
                {
                    var db = new parkingDBWpfContext();
                    _lot.Status = status;
                    db.Lots.Update(_lot);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Lot does not exist!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
