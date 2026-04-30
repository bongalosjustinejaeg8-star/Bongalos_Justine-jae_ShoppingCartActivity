using System;
using System.Collections.Generic;

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
                Console.Clear();
                List<string> options = new List<string>
                {
                    "START SHOPPING",
                    "VIEW PRODUCTS",
                    "SEARCH PRODUCTS",
                    "FILTER BY CATEGORY",
                    "VIEW ORDER HISTORY",
                    "EXIT"
                };
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
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        break;
                    case "3":
                        shop.SearchProduct();
                        break;
                    case "4":
                        shop.FilterByCategory();
                        break;
                    case "5":
                        shop.ViewOrderHistory();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadLine();
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
        public string Category { get; set; }

        public Product(int id, string name, double price, int stock, string category)
        {
            ID = id;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }
    }

    public class OrderRecord
    {
        public int ReceiptNo;
        public double FinalTotal;
        public string DateTime;
    }

    public class Shop
    {
        public Product[] products = new Product[]
        {
            new Product(001, "Laptop", 450, 10, "Gadget"),
            new Product(002, "Mechanical Keyboard", 349, 25, "Keyboard"),
            new Product(003, "Wireless Mouse", 12.99, 40, "Mouse"),
            new Product(004, "27-inch Monitor", 89.00, 15, "Monitor"),
            new Product(005, "USB-C Hub", 79.75, 30, "Accessories")
        };

        public Product[] CartContent = new Product[10];
        double Overall = 0;
        double Discount = 0;
        int CartLimit = 0;
        int MaxCartLimit = 10;
        private int cartItemCount = 0;

        private int receiptCounter = 0;
        private OrderRecord[] orderHistory = new OrderRecord[100];
        private int orderCount = 0;

        // ─────────────────────────────────────────────
        //  DISPLAY & SEARCH
        // ─────────────────────────────────────────────

        public void DisplayProducts()
        {
            int TempNum = 1;
            Console.WriteLine("");
            foreach (var product in products)
            {
                Console.WriteLine($"{TempNum}. Name: {product.Name}, Price: {product.Price:F2}, Stock: {product.Stock}, Category: {product.Category}");
                TempNum++;
            }
            Console.WriteLine("");
        }

        public void SearchProduct()
        {
            Console.Clear();
            Console.Write("Enter product name to search: ");
            string keyword = Console.ReadLine()?.ToLower();
            bool found = false;
            int num = 1;
            foreach (var p in products)
            {
                if (p.Name.ToLower().Contains(keyword))
                {
                    Console.WriteLine($"{num}. {p.Name} - {p.Price:F2} - Stock: {p.Stock} - Category: {p.Category}");
                    found = true;
                }
                num++;
            }
            if (!found) Console.WriteLine("No products found.");
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }

        public void FilterByCategory()
        {
            Console.Clear();
            var categories = new HashSet<string>();
            foreach (var p in products)
                if (!string.IsNullOrEmpty(p.Category)) categories.Add(p.Category);

            Console.WriteLine("Available Categories:");
            int i = 1;
            var catList = new List<string>(categories);
            foreach (var c in catList) Console.WriteLine($"{i++}. {c}");

            Console.Write("\nEnter category name: ");
            string input = Console.ReadLine()?.ToLower();

            bool found = false;
            foreach (var p in products)
            {
                if (p.Category.ToLower() == input)
                {
                    Console.WriteLine($"{p.ID}. {p.Name} - {p.Price:F2} - Stock: {p.Stock}");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("No products found in that category.");
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }

        // ─────────────────────────────────────────────
        //  CART FLOW
        // ─────────────────────────────────────────────

        public void Cart()
        {
            while (true)
            {
                DisplayProducts();
                Console.WriteLine("Please Enter the Number of the Product you want to buy, 'X' to exit, 'V' to view cart: ");
                string Adding = Console.ReadLine();
                Adding = Adding.ToUpper();
                try
                {
                    int parsed = int.Parse(Adding);
                    if (parsed >= 1 && parsed <= products.Length)
                    {
                        Confirmation(parsed - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice. Press Enter.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                catch
                {
                    switch (Adding)
                    {
                        case "X":
                            return;
                        case "V":
                            CartManagementMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice. Press Enter.");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        //  CART MANAGEMENT MENU
        // ─────────────────────────────────────────────

        private void CartManagementMenu()
        {
            while (true)
            {
                Console.Clear();
                ShowCartDisplay();
                Console.WriteLine("CART MENU:");
                Console.WriteLine("1. Remove an item");
                Console.WriteLine("2. Update item quantity");
                Console.WriteLine("3. Clear cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Continue Shopping");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RemoveFromCart(); break;
                    case "2": UpdateCartQuantity(); break;
                    case "3": ClearCart(); break;
                    case "4":
                        if (Overall >= 5000)
                            Discount = Overall - (Overall * 0.10);
                        Checkout();
                        return;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ShowCartDisplay()
        {
            Console.WriteLine("=== YOUR CART ===");
            bool hasItems = false;
            for (int i = 0; i < cartItemCount; i++)
            {
                if (CartContent[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {CartContent[i].Name} | Qty: {CartContent[i].Stock} | Subtotal: {CartContent[i].Price:F2}");
                    hasItems = true;
                }
            }
            if (!hasItems) Console.WriteLine("(Cart is empty)");
            Console.WriteLine($"OVERALL TOTAL: {Overall:F2}");
            Console.WriteLine("=================\n");
        }

        private void RemoveFromCart()
        {
            ShowCartDisplay();
            Console.Write("Enter item number to remove (0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= cartItemCount)
            {
                index--;
                // Restore stock
                foreach (var p in products)
                    if (p.Name == CartContent[index].Name)
                        p.Stock += CartContent[index].Stock;

                Overall -= CartContent[index].Price;
                CartLimit -= CartContent[index].Stock;

                // Shift array left
                for (int i = index; i < cartItemCount - 1; i++)
                    CartContent[i] = CartContent[i + 1];
                CartContent[cartItemCount - 1] = null;
                cartItemCount--;

                Console.WriteLine("Item removed.");
            }
            else
            {
                Console.WriteLine("Cancelled.");
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void UpdateCartQuantity()
        {
            ShowCartDisplay();
            Console.Write("Enter item number to update (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > cartItemCount)
            {
                Console.WriteLine("Cancelled. Press Enter.");
                Console.ReadLine();
                return;
            }

            index--;
            Console.Write($"Enter new quantity for {CartContent[index].Name}: ");
            if (!int.TryParse(Console.ReadLine(), out int newQty) || newQty <= 0)
            {
                Console.WriteLine("Invalid quantity. Press Enter.");
                Console.ReadLine();
                return;
            }

            foreach (var p in products)
            {
                if (p.Name == CartContent[index].Name)
                {
                    int diff = newQty - CartContent[index].Stock;
                    if (diff > p.Stock)
                    {
                        Console.WriteLine("Not enough stock. Press Enter.");
                        Console.ReadLine();
                        return;
                    }

                    p.Stock -= diff;
                    Overall += p.Price * diff;
                    CartLimit += diff;
                    CartContent[index].Stock = newQty;
                    CartContent[index].Price = p.Price * newQty;
                    Console.WriteLine("Quantity updated. Press Enter.");
                    Console.ReadLine();
                    return;
                }
            }
        }

        private void ClearCart()
        {
            string input;
            do
            {
                Console.Write("Clear entire cart? (Y/N): ");
                input = Console.ReadLine()?.ToUpper();
                if (input != "Y" && input != "N")
                    Console.WriteLine("Invalid input. Please enter Y or N only.");
            } while (input != "Y" && input != "N");

            if (input == "Y")
            {
                for (int i = 0; i < cartItemCount; i++)
                {
                    if (CartContent[i] != null)
                        foreach (var p in products)
                            if (p.Name == CartContent[i].Name)
                                p.Stock += CartContent[i].Stock;
                }

                CartContent = new Product[10];
                cartItemCount = 0;
                Overall = 0;
                Discount = 0;
                CartLimit = 0;
                Console.WriteLine("Cart cleared. Press Enter.");
                Console.ReadLine();
            }
        }

        // ─────────────────────────────────────────────
        //  ADD TO CART
        // ─────────────────────────────────────────────

        private void AddToCart(string name, int qty)
        {
            foreach (var product in products)
            {
                if (product.Name == name)
                {
                    if (product.Stock < qty)
                    {
                        Console.WriteLine($"Insufficient stock for {product.Name}!");
                        return;
                    }

                    if (CartLimit + qty > MaxCartLimit)
                    {
                        Console.WriteLine($"Cart limit reached! You can only add {MaxCartLimit - CartLimit} more.");
                        Console.ReadLine();
                        return;
                    }

                    Product existingItem = null;
                    for (int i = 0; i < cartItemCount; i++)
                    {
                        if (CartContent[i].Name == name)
                        {
                            existingItem = CartContent[i];
                            break;
                        }
                    }

                    if (existingItem != null)
                    {
                        existingItem.Price += product.Price * qty;
                        existingItem.Stock += qty;
                    }
                    else
                    {
                        if (cartItemCount < CartContent.Length)
                        {
                            CartContent[cartItemCount] = new Product(product.ID, name, product.Price * qty, qty, product.Category);
                            cartItemCount++;
                        }
                        else
                        {
                            Console.WriteLine("Cart array is full! Cannot add more unique items.");
                            return;
                        }
                    }

                    product.Stock -= qty;
                    Overall += product.Price * qty;
                    CartLimit += qty;

                    Console.Clear();
                    ShowCartDisplay();
                    Console.WriteLine("Item added! Press Enter to continue.");
                    Console.ReadLine();
                    return;
                }
            }
        }

        // ─────────────────────────────────────────────
        //  CONFIRMATION
        // ─────────────────────────────────────────────

        private void Confirmation(int number)
        {
            if (products[number].Stock != 0)
            {
                string TempDescision;
                do
                {
                    Console.Write($"Are you sure you want to add {products[number].Name} to Cart? (Y/N): ");
                    TempDescision = Console.ReadLine()?.ToUpper();
                    if (TempDescision != "Y" && TempDescision != "N")
                        Console.WriteLine("Invalid input. Please enter Y or N only.");
                } while (TempDescision != "Y" && TempDescision != "N");

                if (TempDescision == "Y")
                    Confirmation2(products[number].Name);
                else
                    Console.WriteLine("Cancelled!");
            }
            else
            {
                Console.WriteLine($"Cancelled, {products[number].Name}'s Stock is 0. Press Enter.");
                Console.ReadLine();
            }
        }

        private void Confirmation2(string name)
        {
            Console.Write($"How many {name} would you like to buy? (Press Enter for 1): ");
            string amount = Console.ReadLine();
            int qty = 1;

            if (!string.IsNullOrWhiteSpace(amount))
            {
                if (!int.TryParse(amount, out qty) || qty <= 0)
                {
                    Console.WriteLine("Invalid quantity. Press Enter.");
                    Console.ReadLine();
                    return;
                }
            }

            foreach (var items in products)
            {
                if (items.Name == name)
                {
                    if ((items.Stock - qty) >= 0)
                        AddToCart(name, qty);
                    else
                    {
                        Console.WriteLine($"Stocks for {name} are not enough. Press Enter.");
                        Console.ReadLine();
                    }
                    return;
                }
            }
        }

        // ─────────────────────────────────────────────
        //  CHECKOUT
        // ─────────────────────────────────────────────

        private void Checkout()
        {
            Console.Clear();
            if (Overall <= 0)
            {
                Console.WriteLine("Your cart is empty! Press Enter.");
                Console.ReadLine();
                return;
            }

            if (Overall >= 5000)
                Discounted();
            else
                NormalCheckout();
        }

        private void Discounted()
        {
            receiptCounter++;
            Console.WriteLine($"Overall total: {Overall:F2}");
            Console.WriteLine($"Discounted total (10% off): {Discount:F2}");

            double payment = GetValidPayment(Discount);

            PrintReceipt(payment, Discount, isDiscounted: true);
            LowStockAlert();

            SaveOrderHistory(Discount);
            ResetCart();

            Console.WriteLine("\nPress Enter to Continue");
            Console.ReadLine();
        }

        private void NormalCheckout()
        {
            receiptCounter++;
            Console.WriteLine($"Overall total: {Overall:F2}");

            double payment = GetValidPayment(Overall);

            PrintReceipt(payment, Overall, isDiscounted: false);
            LowStockAlert();

            SaveOrderHistory(Overall);
            ResetCart();

            Console.WriteLine("\nPress Enter to Continue");
            Console.ReadLine();
        }

        private double GetValidPayment(double amountDue)
        {
            double payment = 0;
            while (true)
            {
                Console.Write($"Enter payment (amount due: {amountDue:F2}): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out payment) && payment >= amountDue)
                    return payment;
                else if (!double.TryParse(input, out _))
                    Console.WriteLine("Please enter a valid numeric amount.");
                else
                    Console.WriteLine($"Insufficient payment. Amount due: {amountDue:F2}");
            }
        }

        private void PrintReceipt(double payment, double finalTotal, bool isDiscounted)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine($"Receipt No: {receiptCounter:D4}");
            Console.WriteLine($"Date: {DateTime.Now:MMMM dd, yyyy h:mm tt}");
            Console.WriteLine("==============================================================");
            Console.WriteLine("Items Purchased:");
            for (int i = 0; i < cartItemCount; i++)
            {
                if (CartContent[i] != null)
                    Console.WriteLine($"  {CartContent[i].Name} | Qty: {CartContent[i].Stock} | Subtotal: {CartContent[i].Price:F2}");
            }
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"Grand Total:  {Overall:F2}");
            if (isDiscounted)
            {
                Console.WriteLine($"Discount:     10%");
                Console.WriteLine($"Final Total:  {finalTotal:F2}");
            }
            Console.WriteLine($"Payment:      {payment:F2}");
            Console.WriteLine($"Change:       {(payment - finalTotal):F2}");
            Console.WriteLine("==============================================================");
        }

        // ─────────────────────────────────────────────
        //  LOW STOCK ALERT
        // ─────────────────────────────────────────────

        private void LowStockAlert()
        {
            bool hasLow = false;
            Console.WriteLine("\nLOW STOCK ALERT:");
            foreach (var p in products)
            {
                if (p.Stock <= 5)
                {
                    Console.WriteLine($"  {p.Name} has only {p.Stock} stock(s) left.");
                    hasLow = true;
                }
            }
            if (!hasLow) Console.WriteLine("  All products are sufficiently stocked.");
        }

        // ─────────────────────────────────────────────
        //  ORDER HISTORY
        // ─────────────────────────────────────────────

        private void SaveOrderHistory(double finalTotal)
        {
            if (orderCount < orderHistory.Length)
            {
                orderHistory[orderCount++] = new OrderRecord
                {
                    ReceiptNo = receiptCounter,
                    FinalTotal = finalTotal,
                    DateTime = System.DateTime.Now.ToString("MMMM dd, yyyy h:mm tt")
                };
            }
        }

        public void ViewOrderHistory()
        {
            Console.Clear();
            Console.WriteLine("=== ORDER HISTORY ===");
            if (orderCount == 0)
                Console.WriteLine("No orders yet.");
            else
                for (int i = 0; i < orderCount; i++)
                    Console.WriteLine($"Receipt #{orderHistory[i].ReceiptNo:D4} - Final Total: {orderHistory[i].FinalTotal:F2} - {orderHistory[i].DateTime}");
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }

        // ─────────────────────────────────────────────
        //  HELPERS
        // ─────────────────────────────────────────────

        private void ResetCart()
        {
            CartContent = new Product[10];
            cartItemCount = 0;
            Overall = 0;
            Discount = 0;
            CartLimit = 0;
        }
    }
}