using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public class BillDAO : IDao<Bill>
    {
        public void Add(Bill obj)
        {
            using (var db = new DBStoreManagementEntities())
            {
                db.Bills.Add(obj);
                db.SaveChanges();
            }
        }

        public void Delete(Bill obj)
        {
            throw new NotImplementedException();
        }

        public Bill Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bill> GetAll()
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Bills.ToList();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " GetAll() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public void Update(Bill obj)
        {
            throw new NotImplementedException();
        }
    }
}
