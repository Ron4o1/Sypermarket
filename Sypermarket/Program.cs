using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Sypermarket
{
    internal class Program
    {
        private const string FilePath = "products.txt";
        static void Main(string[] args)
        {
            Console.WriteLine(File.Exists(FilePath));
            Console.WriteLine(Path.GetFullPath(FilePath));
            List<Product> products = LoadProducts(FilePath);

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
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Въведете ID: ");
                        string productID = Console.ReadLine();

                        Console.Write("Въведете име: ");
                        string name = Console.ReadLine();

                        Console.Write("Въведете категория: ");
                        string category = Console.ReadLine();

                        Console.Write("Въведете цена: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Въведете количество: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Product newProduct = new Product(productID, name, category, price, quantity);
                        products.Add(newProduct);

                        SaveProducts(products);
                        Console.WriteLine("Успешно добавен нов запис!");
                        Console.WriteLine();
                        break;

                    case "2":
                        SellProduct(products);
                        break;

                    case "3":
                        CheckProduct(products);
                        break;
                }
            }
        }

        static List<Product> LoadProducts(string FilePath)
        {
            List<Product> products = new List<Product>();

            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');

                    Product p = new Product(
                        data[0],
                        data[1],
                        data[2],
                        double.Parse(data[3]),
                        int.Parse(data[4])
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
            File.WriteAllLines(FilePath, lines);
        }

        static void AddProduct(List<Product> products)
        {
            Console.Write("ID: ");
            string id = Console.ReadLine();

            Console.Write("Име: ");
            string name = Console.ReadLine();

            Console.Write("Категория: ");
            string category = Console.ReadLine();

            Console.Write("Цена: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Количество: ");
            int quantity = int.Parse(Console.ReadLine());

            Product p = new Product(id, name, category, price, quantity);

            products.Add(p);

            SaveProducts(products);

            Console.WriteLine("Продуктът е добавен успешно!");
        }

        static void SellProduct(List<Product> products)
        {
            Console.Write("Въведете име на продукта: ");
            string name = Console.ReadLine();

            Product p = products.Find(x => x.Name == name);

            if (p == null)
            {
                Console.WriteLine("Няма такъв продукт!");
                return;
            }

            Console.Write("Количество за продажба: ");
            int quantity = int.Parse(Console.ReadLine());

            if (p.Quantity >= quantity)
            {
                double totalPrice = quantity * p.Price;

                p.Quantity -= quantity;

                SaveProducts(products);

                Console.WriteLine($"Обща цена: {totalPrice} лв.");
                Console.WriteLine("Продажбата е успешна.");
            }
            else
            {
                Console.WriteLine("Недостатъчно количество!");
            }
        }

        static void CheckProduct(List<Product> products)
        {
            Console.Write("Въведете име на продукта: ");
            string name = Console.ReadLine();

            Product p = products.Find(x => x.Name == name);

            if (p != null)
            {
                Console.WriteLine($"Цена: {p.Price} лв.");
                Console.WriteLine($"Налично количество: {p.Quantity}");
            }
            else
            {
                Console.WriteLine("Няма такъв продукт.");
            }
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
