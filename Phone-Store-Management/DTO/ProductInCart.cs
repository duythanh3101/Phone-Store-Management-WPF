using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DTO
{
    public class ProductInCart
    {
        private int count;
        private double totalprice;
       
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Brand { get; set; }
        public int TypeId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ImageURL{ get; set;}

        // Quantity of products in Cart
        public int Count
        {
            get { return count; }
            set
            {
                if (value <= Quantity)
                {
                    count = value;
                }
                else
                {
                    count = Quantity;
                }
                totalprice = count * Price;

            }
        }  

        //Total price of products in cart
        public Double TotalPrice
        {
            get { return count * Price; }
            set
            {
                totalprice = value;
            }
        }

        public ProductInCart(int id, string displayName, string brand, int typeId, double price,
           string description, int quantity, string imageURL, int count)
        {
            Id = id;
            DisplayName = displayName;
            Brand = brand;
            TypeId = typeId;
            Price = price;
            Description = description;
            Quantity = quantity;
            ImageURL = imageURL;
            this.count = count;
        }

        public double GetTotalPrice()
        {
            return (float)Price * Count;
        }
    }
}
