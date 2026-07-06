using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sypermarket
{
     class Product
    {
        public Product(string productID, string name, string category, double price, int quantity)
        {
            ProductID = productID;
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public string ProductID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string ToFileRow()
        {
            return $"{ProductID};{Name};{Category};{Price};{Quantity}";
        }

        public override string ToString()
        {
            return $"Ид: {ProductID}, Име: {Name}, Категория: {Category}, Цена: {Price:F2}, Количество: {Quantity}";
        }

        public static Product FromFileRow(string row)
        {
            string[] parts = row.Split(';');
            if (parts.Length == 5)
            {
                string productID = parts[0];
                string name = parts[1];
                string category = parts[2];
                double price = double.Parse(parts[3]);
                int quantity = int.Parse(parts[4]);
                return new Product(productID, name, category, price, quantity);
            }
            return null;
        }
     }
 }
