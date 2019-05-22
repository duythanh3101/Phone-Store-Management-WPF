using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Entities
{
    public class Basket
    {
        public int Id { get; set; }

        public ObservableCollection<BasketDetails> Details
        {
            get => details;
            set
            {
                details = value;
            }
        }

        private ObservableCollection<BasketDetails> details = new ObservableCollection<BasketDetails>();

        public void AddDetail(int productId, double unitPrice, string productName, int amount, int quantity = 1)
        {
            // Add new product to the basket if it doesn't exist.
            if (!Details.Any(d => d.ProductId == productId))
            {
                details.Add(new BasketDetails()
                {
                    ProductId = productId,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    ProductName = productName
                });
                return;
            }

            // Otherwise find the existing detail and update its quantity.
            var existingDetail = Details.FirstOrDefault(i => i.ProductId == productId);
            if (existingDetail.Quantity < amount)
            {
                existingDetail.Quantity += quantity;
            }
        }

        public double TotalPrice()
        {
            return details.Sum(detail => detail.UnitPrice * detail.Quantity);
        }
    }
}
