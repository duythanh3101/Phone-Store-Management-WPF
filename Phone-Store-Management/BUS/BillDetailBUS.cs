using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.BUS
{
    public class BillDetailBUS
    {
        private BillDetailDAO billDetailDAO = new BillDetailDAO();
        public List<BillDetail> GetAll()
        {
            return billDetailDAO.GetAll();
        }

        public List<BillDetail> GetAllByID(int id)
        {
            return billDetailDAO.GetAll().FindAll(b => b.BillId == id);
        }
    }
}
