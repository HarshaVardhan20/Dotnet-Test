using System;

namespace Assignment2
{
    internal class Program
    {
        // Fields: stores shared program state
        #region Fields

        // Last saved SaleTransaction
        static SaleTransaction LastTransaction;
        // Indicates whether there is a saved last transaction
        static bool HasLastTransaction = false;

        #endregion

        // Methods: user interactions and computations
        #region Methods

        /// <summary>
        /// Prompts the user to enter transaction details, validates input,
        /// creates a SaleTransaction, stores it as the last transaction,
        /// and prints a brief summary (status, profit/loss amount and margin).
        /// </summary>
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

        /// <summary>
        /// Displays the last saved transaction's details (invoice, customer, item,
        /// quantities, amounts and computed profit/loss information). If none exists,
        /// notifies the user.
        /// </summary>
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

        /// <summary>
        /// Recomputes and prints whether the last transaction resulted in a profit,
        /// a loss, or break-even. If no transaction is available, notifies the user.
        /// </summary>
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

        /// <summary>
        /// Application entry point. Presents a simple console menu to create/view/recompute
        /// transactions or exit.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
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
        #endregion
    }
}