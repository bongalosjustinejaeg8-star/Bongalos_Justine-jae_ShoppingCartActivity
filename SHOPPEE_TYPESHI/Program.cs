using System;

namespace Shopping
{
   class Program
    {
        static void Main()
        {
            int num = 1;
            List<string> options = ["START SHOPPING","VIEW PRODUCTS", "SEARCH PRODUCTS", "EXIT"];
            Console.WriteLine("WELCOME to SHOPPEE TYPESHI");
            foreach (var words in options)
            {
                Console.WriteLine($"{num}.  {words}");
                num++;
            }

        }
    } 
}