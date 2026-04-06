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
                List<string> options = ["START SHOPPING", "VIEW PRODUCTS", "SEARCH PRODUCTS", "EXIT"];
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
}