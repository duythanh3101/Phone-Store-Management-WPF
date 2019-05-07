using Phone_Store_Management.DTO;
using Phone_Store_Management.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public class ProductDAO : IDao<Product>
    {
        public void Delete(Product t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var del = (from p in db.Products
                                   where p.Id == t.Id
                                   select p).Single();
                    if (del != null)
                    {
                        db.Products.Remove(del);
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception e)
            {
                var log = new LogError(GetType().Name + " Delete() is error" + "\n" + e.Message);
                log.Show();
            }
        }

        public Product Get(long id)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Products.Find(id);
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Get() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;

        }

        public List<Product> GetAll()
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Products.ToList();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " GetAll() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public void Add(Product t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    db.Products.Add(t);
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Add() is error" + "\n" + e.Message);
                log.Show();
            }
        }

        public void Update(Product t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var product = db.Products.Find(t.Id);
                    product.DisplayName = t.DisplayName;
                    product.Brand = t.Brand;
                    product.TypeId = t.TypeId;
                    product.Price = t.Price;
                    product.Description = t.Description;
                    product.Quantity = t.Quantity;
                    product.ImageURL = t.ImageURL;
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
