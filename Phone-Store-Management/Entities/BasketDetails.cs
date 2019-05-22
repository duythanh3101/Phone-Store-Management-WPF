using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Entities
{
    public class BasketDetails
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double TotalPrice
        {
            get => UnitPrice * Quantity;
            set
            {           
               value = UnitPrice * Quantity;
            }
        }
    }
}
