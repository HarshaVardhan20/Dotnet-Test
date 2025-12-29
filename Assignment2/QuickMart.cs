using System;
using System.Collections.Generic;

namespace Assignment2
{
    /// <summary>
    /// Represents a sale transaction containing invoice, customer, item, quantity,
    /// amounts and computed profit/loss information.
    /// </summary>
    // SaleTransaction class -- Base Transaction class
    public class SaleTransaction
    {
        // Fields: transaction data
        #region Fields

        // Invoice number for the transaction
        public string InvoiceNo;
        // Customer name for the transaction
        public string CustomerName;
        // Item name sold in the transaction
        public string ItemName;
        // Quantity of items sold
        public int Quantity;
        // Purchase amount per transaction
        public decimal PurchaseAmount;
        // Selling amount per transaction
        public decimal SellingAmount;
        // Computed status: "PROFIT", "LOSS", or "BREAK-EVEN"
        public string ProfitOrLossStatus;
        // Computed absolute profit or loss amount
        public decimal ProfitOrLossAmount;
        // Computed profit margin percentage
        public decimal ProfitMarginPercent;

        #endregion

        // SaleTransaction Constructor
        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="SaleTransaction"/> with the provided
        /// invoice, customer, item, quantity and amounts. Computes the profit/loss status,
        /// amount and profit margin percent based on the purchase and selling amounts.
        /// </summary>
        public SaleTransaction(string InvoiceNo, string CustomerName, string ItemName, int Quantity, decimal PurchaseAmount, decimal SellingAmount)
        {
            this.InvoiceNo = InvoiceNo;
            this.CustomerName = CustomerName;
            this.ItemName = ItemName;
            this.Quantity = Quantity;
            this.PurchaseAmount = PurchaseAmount;
            this.SellingAmount = SellingAmount;

            if (SellingAmount > PurchaseAmount)
            {
                this.ProfitOrLossStatus = "PROFIT";
                this.ProfitOrLossAmount = SellingAmount - PurchaseAmount;
            }
            else if (SellingAmount < PurchaseAmount)
            {
                this.ProfitOrLossStatus = "LOSS";
                this.ProfitOrLossAmount = PurchaseAmount - SellingAmount;
            }
            else
            {
                this.ProfitOrLossStatus = "BREAK-EVEN";
                this.ProfitOrLossAmount = 0;
            }

            this.ProfitMarginPercent = (this.ProfitOrLossAmount / PurchaseAmount) * 100;
        }

        #endregion
    }
}