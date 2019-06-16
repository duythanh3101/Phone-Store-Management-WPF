using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public class WarrantyDAO: IDao<Warranty>
    {

        public void Add(Warranty t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    db.Warranties.Add(t);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Add() is error" + "\n" + e.Message);
                log.Show();
            }
        }

        public void Delete(Warranty t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var del = (from p in db.Warranties
                               where p.PhoneNumber == t.PhoneNumber
                               select p).Single();
                    if (del != null)
                    {
                        db.Warranties.Remove(del);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Delete() is error" + "\n" + e.Message);
                log.Show();
            }
        }

        public Warranty Get(int id)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Warranties.Find(id);
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Get() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public List<Warranty> Get(string phoneNumber)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Warranties.Where(w => w.PhoneNumber == phoneNumber).ToList();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Get() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public List<Warranty> GetAll()
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Warranties.ToList();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " GetAll() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public void Update(Warranty t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var entity = db.Warranties.Find(t.PhoneNumber);
                    if (entity == null)
                    {
                        return;
                    }

                    db.Entry(entity).CurrentValues.SetValues(t);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Update() is error" + "\n" + e.Message);
                log.Show();
            }
        }
    }
}
