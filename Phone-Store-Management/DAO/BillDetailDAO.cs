using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public class BillDetailDAO : IDao<BillDetail>
    {
        public void Add(BillDetail obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(BillDetail obj)
        {
            throw new NotImplementedException();
        }

        public BillDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BillDetail> GetAll()
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.BillDetails.ToList();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " GetAll() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public void Update(BillDetail obj)
        {
            throw new NotImplementedException();
        }
    }
}
