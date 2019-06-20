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
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    //Delete all bill details
                    List<BillDetail> details = (from rows in db.BillDetails where rows.BillId == obj.Id select rows).ToList();
                    foreach (var item in details)
                    {
                        db.BillDetails.Remove(item);    
                    }

                    //After that delete bill
                    obj = (from rows in db.Bills where obj.Id == rows.Id select rows).SingleOrDefault();
                    if (obj != null)
                    {
                        db.Bills.Remove(obj);
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

        public Bill Get(int id)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    Bill bill = db.Bills.Find(id);
                    ICollection<BillDetail> lst = (from rows in db.BillDetails where rows.BillId == bill.Id select rows).ToList();
                    bill.BillDetails = lst;
                    return bill;
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Get() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
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
