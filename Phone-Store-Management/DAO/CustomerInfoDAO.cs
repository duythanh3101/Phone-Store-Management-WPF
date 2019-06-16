using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public class CustomerInfoDAO: IDao<CustomerInfo>
    {

        public void Add(CustomerInfo t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    db.CustomerInfoes.Add(t);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Add() is error" + "\n" + e.Message);
                log.Show();
            }
        }

        public void Delete(CustomerInfo t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var del = (from p in db.CustomerInfoes
                               where p.PhoneNumber == t.PhoneNumber
                               select p).Single();
                    if (del != null)
                    {
                        db.CustomerInfoes.Remove(del);
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

        public CustomerInfo Get(int id)
        {
            return null;
        }

        public CustomerInfo Get(string phoneNumber)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.CustomerInfoes.Find(phoneNumber);
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Get() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public List<CustomerInfo> GetAll()
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.CustomerInfoes.ToList();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " GetAll() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public void Update(CustomerInfo t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var entity = db.CustomerInfoes.Find(t.PhoneNumber);
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

        public bool IsExisted(string PhoneNumber)
        {
            return Get(PhoneNumber) != null ? true : false;
        }
    }
}
