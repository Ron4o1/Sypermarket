using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Sypermarket
{
    internal class Program
    {
        static string fileName = "products.txt";
        static void Main(string[] args)
        {
            List<Product> products = LoadProducts(fileName);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("--- ХРАНИТЕЛЕН МАГАЗИН ---");
                Console.WriteLine("1. Добавяне на продукт");
                Console.WriteLine("2. Продажба на продукт");
                Console.WriteLine("3. Проверка на продукт");
                Console.WriteLine("4. Справка на наличност");
                Console.WriteLine("5. Изход");
                Console.WriteLine("Избор:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(products);
                        break;

                    case "2":
                        SellProduct(products);
                        break;

                    case "3":
                        CheckProduct(products);
                        break;

                    case "4":
                        ShowInventory(products);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Невалиден избор. Моля, опитайте отново.");
                        break;
                }
            }
        }

        static List<Product> LoadProducts(string fileName)
        {
            List<Product> products = new List<Product>();

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    Product p = new Product(
                        data[0],
                        data[1],
                        data[2],
                        double.Parse(data[4])
                        );
                }
            }
            return products;
        }

        static void SaveProducts(List<Product> products)
        {
            List<string> lines = new List<string>();

            foreach (Product p in products)
            {
                lines.Add($"{p.ProductID},{p.Name},{p.Category},{p.Price},{p.Quantity}");
            }
            File.WriteAllLines(fileName, lines);
        }

        static void ShowProducts(List<Product> products)

        {

            Console.WriteLine();

            foreach (Product p in products)
            {

                Console.WriteLine("--------------------");

                Console.WriteLine($"ID: { p.ProductID}");

                Console.WriteLine($"Име: { p.Name}");

                Console.WriteLine($"Категория: { p.Category}");

                Console.WriteLine($"Цена: { p.Price} лв.");

                Console.WriteLine($"Количество: { p.Quantity}");

            }
        }
    }
}
