using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml;
using System.Collections.Generic; 
using System.Diagnostics.Contracts;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");

                Console.Write("Common, used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(
                    Console.ReadLine(),
                    CultureInfo.InvariantCulture
                );

                if (ch == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(
                        Console.ReadLine(),
                        CultureInfo.InvariantCulture
                    );

                    products.Add(
                        new ImportedProduct(
                            name,
                            price,
                            customsFee
                        )
                    );
                }
                else if (ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.ParseExact(
                        Console.ReadLine(),
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    );

                    products.Add(
                        new UsedProduct(
                            name,
                            price,
                            manufactureDate
                        )
                    );
                }
                else
                {
                    products.Add(
                        new Product(
                            name,
                            price
                        )
                    );
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            foreach (Product p in products)
            {
                Console.WriteLine(p.PriceTag());
            }
        }
    }
}