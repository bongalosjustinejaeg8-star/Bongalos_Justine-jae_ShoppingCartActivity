using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shopping
{
    public class Program
    {
        public static void Main()
        {
            Shop shop = new Shop();
            while (true)
            {
                int num = 1;
                List<string> options = ["START SHOPPING", "VIEW PRODUCTS", "ADD PRODUCT", "EXIT"];
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
                        Console.Clear();
                        shop.Cart();
                        break;
                    case "2":
                        shop.DisplayProducts();
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
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(int ID, string name, double price, int stock)
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
            new Product(001,"Laptop", 450, 10),
            new Product(002,"Mechanical Keyboard", 349, 25),
            new Product(003,"Wireless Mouse", 12.99, 40),
            new Product(004,"27-inch Monitor", 89.00, 15),
            new Product(005,"USB-C Hub", 79.75, 30)
        };
        public List<Product> CartContent = new List<Product>();

        public void DisplayProducts()
        {
            int TempNum = 1;
            Console.WriteLine("");
            foreach (var product in products)
            {
                Console.WriteLine($"{TempNum}. Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
                TempNum++;
            }
            Console.WriteLine("");
        }
        public void Cart()
        {
            DisplayProducts();
            Console.WriteLine("Please Enter the Number of the Product you wanna buy, 'X' to exit & C for checkout: ");
                string Adding = Console.ReadLine();
                switch (Adding.ToUpper())
                {
                case "1":
                    Confirmation(int.Parse(Adding)-1);
                    break;
                case "2":
                    Confirmation(int.Parse(Adding) - 1);
                    break;
                case "3":
                    Confirmation(int.Parse(Adding) - 1);
                    break;
                case "4":
                    Confirmation(int.Parse(Adding) - 1);
                    break;
                case "5":
                    Confirmation(int.Parse(Adding) - 1);
                    break;
                case "X":
                    Shopping.Program.Main();
                    return;
                default:
                    Console.WriteLine("Non Existing Product");
                    Cart();
                    break;

                }
            


        }
        private void AddToCart(string name, int qty)
        {
            foreach (var items in products)
            {
                if (items.Name == name)
                {
                    if ((items.Stock - qty) >= 0)
                    {
                        if (CartContent.Count == 0)
                        {
                            CartContent.Add(new Product(items.ID, name, (items.Price) * qty, qty));
                            items.Stock -= qty;
                            ShowCart(qty);
                        }
                        else if (CartContent.Count<=5)
                        {
                            CartContent.Add(new Product(items.ID, name, (items.Price) * qty, qty));
                            items.Stock -= qty;
                            ShowCart(qty);
                        }
                        else
                        {
                            foreach (var content in CartContent)
                            {
                                if (content.Name == name)
                                {
                                    content.Price += (items.Price) * qty;
                                    content.Stock += qty;
                                    items.Stock -= qty;
                                    ShowCart(content.Stock);
                                }
                                else
                                {
                                    CartContent.Add(new Product(items.ID, name, (items.Price) * qty, qty));
                                    items.Stock -= qty;
                                    ShowCart(qty);
                                }
                            }
                        }

                    }
                }
            }
        }
        private void Confirmation(int number)
        {
            Console.WriteLine($"are you sure you wanna add {products[number].Name} to Cart? Y/N ");
            string TempDescision = Console.ReadLine();
            if (TempDescision.ToUpper() == "Y")
            {
                Confirmation2(products[number].Name);
            }
            else
            {
                Console.WriteLine("Cancelled!");
                Cart();
            }

        }
        private void Confirmation2(string name)
        {
            Console.WriteLine($"How Many {name} would you buy?: ");
            string amount = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(amount) == false)
            {
                int qty = int.Parse(amount);
                foreach (var items in products)
                {
                    if (items.Name == name)
                    {
                        if ((items.Stock - qty) >= 0)
                        {
                            AddToCart(name, qty);

                        }
                        else
                        {
                            Console.WriteLine($"Stocks for {name} is not enough");
                            Confirmation2(name);
                        }
                    }
                }
            }
            else
            {
                foreach (var items in products)
                {
                    if (items.Name == name)
                    {
                        if ((items.Stock - 1) >= 0)
                        {
                            AddToCart(name, 1);

                        }
                        else
                        {
                            Console.WriteLine($"Stocks for {name} is not enough");
                            Confirmation2(name);
                        }
                    }
                }
            }
        }
        private void ShowCart(int qty)
        {
            double Overall = 0;
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Your Cart: ");
            foreach (var item in CartContent)
            {
                Console.WriteLine($"Name: {item.Name} qty: {qty} Price: {item.Price} SubTotal: {(item.Price * qty)}");
                Overall += (item.Price * qty);
                
            }
            Console.WriteLine("OVERALL TOTAL: " + Overall);
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("");
            Cart();
        }

    }
}