using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    // SaleTransaction class -- Base Transaction class
    public class SaleTransaction
    {
        public string InvoiceNo;
        public string CustomerName;
        public string ItemName;
        public int Quantity;
        public decimal PurchaseAmount;
        public decimal SellingAmount;
        public string ProfitOrLossStatus;
        public decimal ProfitOrLossAmount;
        public decimal ProfitMarginPercent;

        // SaleTransaction Constructor

        public SaleTransaction(string InvoiceNo,string CustomerName, string ItemName, int Quantity, decimal PurchaseAmount, decimal SellingAmount)
        {
            this.InvoiceNo = InvoiceNo;
            this.CustomerName = CustomerName;
            this.ItemName = ItemName;
            this.Quantity  = Quantity;
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
        
    }
}
