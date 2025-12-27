using System;

namespace Assignment2
{
    internal class Program
    {
        // static last transaction object
        static SaleTransaction LastTransaction;
        // static boolean whether for lastTransaction 
        static bool HasLastTransaction = false;

        // Method to create a new Transaction
        public void CreateTransaction()
        {
            Console.Write("Enter Invoice No: ");
            string? invoiceNo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(invoiceNo))
            {
                Console.WriteLine("Invoice No must not be empty");
                return;
            }

            Console.Write("Enter Customer Name: ");
            string? customerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(customerName))
            {
                Console.WriteLine("Customer Name must not be empty");
                return;
            }

            Console.Write("Enter Item Name: ");
            string? itemName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(itemName))
            {
                Console.WriteLine("Item Name must not be empty");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero");
                return;
            }

            Console.Write("Enter Purchase Amount: ");
            if (!int.TryParse(Console.ReadLine(), out int purchaseAmount) || purchaseAmount <= 0)
            {
                Console.WriteLine("Purchase Amount must be greater than zero");
                return;
            }

            Console.Write("Enter Selling Amount: ");
            if (!int.TryParse(Console.ReadLine(), out int sellingAmount) || sellingAmount <= 0)
            {
                Console.WriteLine("Selling Amount must be greater than zero");
                return;
            }

            SaleTransaction sale = new SaleTransaction(
                invoiceNo,
                customerName,
                itemName,
                quantity,
                purchaseAmount,
                sellingAmount
            );

            LastTransaction = sale;
            HasLastTransaction = true;

            Console.WriteLine("\nTransaction saved successfully.");
            Console.WriteLine($"Status: {sale.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {sale.ProfitOrLossAmount}");
            Console.WriteLine($"Profit Margin (%): {sale.ProfitMarginPercent}");
            Console.WriteLine("--------------------------------------------------");
        }

        // Method to view Previous Transaction
        public void ViewTransaction()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available.");
                return;
            }

            Console.WriteLine("---------- Last Transaction ----------");
            Console.WriteLine($"Invoice No: {LastTransaction.InvoiceNo}");
            Console.WriteLine($"Customer Name: {LastTransaction.CustomerName}");
            Console.WriteLine($"Item Name: {LastTransaction.ItemName}");
            Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
            Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount}");
            Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount}");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount}");
            Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent}");
            Console.WriteLine("--------------------------------------");
        }

        // Method to Recomputer aned show the output of profit or loss.
        public void ReCompute()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available.");
                return;
            }

            if (LastTransaction.ProfitOrLossStatus == "PROFIT")
                Console.WriteLine($"Profit of {LastTransaction.ProfitOrLossAmount}");
            else if (LastTransaction.ProfitOrLossStatus == "LOSS")
                Console.WriteLine($"Loss of {LastTransaction.ProfitOrLossAmount}");
            else
                Console.WriteLine("Break-Even");
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("\n================ QuickMart Traders ================");
                Console.WriteLine("1. Create New Transaction");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            p.CreateTransaction();
                            break;
                        case 2:
                            p.ViewTransaction();
                            break;
                        case 3:
                            p.ReCompute();
                            break;
                        case 4:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                }
            }
        }
    }
}
