using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sypermarket
{
    internal class Product
    {

     class Product
    {
        public string ProductID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

     public Product()
        {

        }


        public Product(string id, string name, string category, double price, int quantity)
        {
            ProductID = id;
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
         
        }
    }
}
