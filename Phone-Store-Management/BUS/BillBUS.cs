using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.BUS
{
    public class BillBUS
    {
        private BillDAO billDAO = new BillDAO();

        public ObservableCollection<Bill> GetAll(DateTime startDate, DateTime endDate, int CashierID)
        {
            List<Bill> lst = billDAO.GetAll();

            lst = lst.FindAll(b => b.BillDate >= startDate);
            lst = lst.FindAll(b => b.BillDate <= endDate);
            lst = lst.FindAll(b => b.CashierID == CashierID);
            if (lst.Count > 0)
            {
                return new ObservableCollection<Bill>(lst);
            }
            return null;
        }

        public List<Bill> GetAllByID(int UserID)
        {
            return billDAO.GetAll().FindAll(d => d.CashierID == UserID);
        }

        public List<Bill> GetAll()
        {
            //return new ObservableCollection<Bill>(billDAO.GetAll());
            return billDAO.GetAll();
        }

        public void Delete(Bill bill)
        {
            billDAO.Delete(bill);
        }

        public Bill Get(int id)
        {
            return billDAO.Get(id);
        }
    }
}
