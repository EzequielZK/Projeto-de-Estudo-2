using System;
using System.Collections.Generic;
using OrderApp.Entities.Enums;
using OrderApp.Entities;
using System.Globalization;

namespace OrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.WriteLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Enter order data:");
            Console.WriteLine();

            Console.Write("Status: ");
            string s = Console.ReadLine();
            OrderStatus status;
            Enum.TryParse<OrderStatus>(s, true, out status);
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            for(int i = 1;i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Product product = new Product(productName, price);
                OrderItem item = new OrderItem(quantity, price, product);

                order.Itens.Add(item);

            }

            Console.WriteLine(order);
            Console.ReadLine();

        }
    }
}
