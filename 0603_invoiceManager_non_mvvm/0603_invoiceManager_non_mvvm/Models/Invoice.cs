namespace _0603_invoiceManager_non_mvvm.Models
{
    // Represents an invoice and encapsulates VAT calculation and text formatting
    public class Invoice
    {
        // Company name is fixed for all invoices
        public string CompanyName { get; } = "WPFBau";

        // Customer details filled by user
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }

        // Product details
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }

        // Calculates the total price including 20% VAT
        public decimal CalculateTotalPrice()
        {
            decimal net = Quantity * PricePerUnit;  // net amount
            decimal vat = net * 0.20m;              // 20% VAT
            return net + vat;                       // gross total
        }

        // Builds the full invoice text for saving to file
        public string BuildInvoiceText()
        {
            return $"Company: {CompanyName}\n" +
                   $"Customer: {CustomerName} ({CustomerNumber})\n" +
                   $"Product: {Description}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Unit Price: {PricePerUnit:C}\n" +
                   $"Total (incl. VAT): {CalculateTotalPrice():C}\n";
        }
    }
}
