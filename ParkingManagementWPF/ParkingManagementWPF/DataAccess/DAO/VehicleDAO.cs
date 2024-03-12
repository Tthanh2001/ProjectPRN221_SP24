using _DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccess.DAO
{
    public class VehicleDAO
    {
        private static VehicleDAO instance = null;
        private static readonly object iLock = new object();
        public VehicleDAO()
        {
        }

        public static VehicleDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new VehicleDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Vehicle> GetByUserId(int id)
        {
            IEnumerable<Vehicle> vehicle = null;
            try
            {
                var db = new parkingDBWpfContext();
                vehicle = db.Vehicles.Include(c => c.Type).Include(c => c.Invoices).Where(c => c.UserId==id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
            }
            return vehicle;
        }

        public Vehicle GetByVehicleCode(string code)
        {
            Vehicle vehicle = null;
            try
            {
                var db = new parkingDBWpfContext();
                vehicle = db.Vehicles.Include(c => c.Type).Include(c => c.Invoices).SingleOrDefault(c => c.VehicleCode.Equals(code));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { 
            }
            return vehicle;
        }

        public void Add(Vehicle vehicle)
        {
            try
            {
                Vehicle _vehicle = GetByVehicleCode(vehicle.VehicleCode);
                if (_vehicle == null)
                {
                    var db = new parkingDBWpfContext();
                    db.Vehicles.Add(vehicle);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Vehicle is existed");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(string code)
        {
            try
            {
                Vehicle _vehicle = GetByVehicleCode(code);
                if (_vehicle != null)
                {
                    var db = new parkingDBWpfContext();
                    db.Vehicles.Remove(_vehicle);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Vehicle does not exist!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateIsParking(string code, bool isParking)
        {
            try
            {
                Vehicle _vehicle = GetByVehicleCode(code);
                if (_vehicle != null)
                {
                    var db = new parkingDBWpfContext();
                    _vehicle.IsParking = isParking;
                    db.Vehicles.Update(_vehicle);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Vehicle does not exist!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
