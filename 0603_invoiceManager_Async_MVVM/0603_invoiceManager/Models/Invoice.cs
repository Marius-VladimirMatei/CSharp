using System;

namespace _0603_invoiceManager_Async_MVVM.Models
{
    // Model representing an invoice - capture invoice data)
    public class Invoice
    {
        // Company name fixed for all invoices
        public string CompanyName { get; } = "WPFBau"; // Preset company name


        // Customer name
        public string CustomerName { get; set; }

        // Customer number in format KU-xxxx
        public string CustomerNumber { get; set; }

        // Product description
        public string Description { get; set; }

        // Quantity of goods
        public int Quantity { get; set; }

        // Price per piece
        public decimal PricePerUnit { get; set; }

        // Calculates total price including 20% VAT
        public decimal CalculateTotalPrice()
        {
            var net = Quantity * PricePerUnit;

            // 0.20m m indicates a decimal literal in C# - used to avoid errorr from double precision
            var vat = net * 0.20m; // 20% VAT
            return net + vat;
        }
    }
}
