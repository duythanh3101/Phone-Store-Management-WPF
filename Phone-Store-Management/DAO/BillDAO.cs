using Phone_Store_Management.Entities;
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
            throw new NotImplementedException();
        }

        public void Update(Bill obj)
        {
            throw new NotImplementedException();
        }
    }
}
