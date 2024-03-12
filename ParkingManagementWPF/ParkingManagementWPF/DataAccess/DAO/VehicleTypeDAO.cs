using _DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccess.DAO
{
    public class VehicleTypeDAO
    {
        private static VehicleTypeDAO instance = null;
        private static readonly object iLock = new object();
        public VehicleTypeDAO()
        {
        }

        public static VehicleTypeDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new VehicleTypeDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<VehicleType> GetAll()
        {
            List<VehicleType> types;
            try
            {
                var db = new parkingDBWpfContext();
                types = db.VehicleTypes.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return types;
        }

        public VehicleType GetById(int id)
        {
            VehicleType type = null;
            try
            {
                var db = new parkingDBWpfContext();
                type = db.VehicleTypes.SingleOrDefault(c => c.TypeId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return type;
        }

        public VehicleType GetByName(string name)
        {
            VehicleType type = null;
            try
            {
                var db = new parkingDBWpfContext();
                type = db.VehicleTypes.SingleOrDefault(c => c.Name.ToLower().Equals(name.ToLower()));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return type;
        }

        public void Update(VehicleType type)
        {
            try
            {
                VehicleType _type = GetById(type.TypeId);
                if (_type != null)
                {
                    _type.PricePerHour = type.PricePerHour;
                    _type.PricePerDay = type.PricePerDay;
                    _type.PricePerWeek = type.PricePerWeek;
                    _type.PricePerMonth = type.PricePerMonth;
                    _type.PricePerYear = type.PricePerYear;
                    var db = new parkingDBWpfContext();
                    db.VehicleTypes.Update(_type);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find vehicle type");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
