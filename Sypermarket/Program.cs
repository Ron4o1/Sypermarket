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
            }
            
        }
    }
}
