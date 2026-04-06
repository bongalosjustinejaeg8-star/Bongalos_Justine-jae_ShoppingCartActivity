using System;
using System.ComponentModel;

namespace Shopping
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                int num = 1;
                List<string> options = ["START SHOPPING", "VIEW PRODUCTS", "SEARCH PRODUCTS","ADD PRODUCT", "EXIT"];
                Console.WriteLine("WELCOME to SHOPPEE TYPESHI");
                foreach (var words in options)
                {
                    Console.WriteLine($"{num}.  {words}");
                    num++;
                }
                string customer_descision = Console.ReadLine();
                switch (customer_descision)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            }

        }

    }
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
    public class Shop
    {
        public List<Product> products = new List<Product>
        {
            new Product("Laptop", 45999.99, 10),
            new Product("Mechanical Keyboard", 3499.50, 25),
            new Product("Wireless Mouse", 1299.99, 40),
            new Product("27-inch Monitor", 8999.00, 15),
            new Product("USB-C Hub", 799.75, 30)
        };

    }
}