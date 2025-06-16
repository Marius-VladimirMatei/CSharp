using System;
using System.Globalization;
using System.Windows;
using _0603_invoiceManager_non_mvvm.Models;
using _0603_invoiceManager_non_mvvm.Services;

namespace _0603_invoiceManager_non_mvvm.Views
{
    // Code-behind for MainWindow.xaml, handling invoice logic directly
    public partial class MainWindow : Window
    {
        private readonly IValidationService _validationService;
        private readonly IFileService _fileService;
        private readonly Invoice _invoice;

        public MainWindow()
        {
            InitializeComponent();
            _validationService = new ValidationService();
            _fileService = new FileService();
            _invoice = new Invoice();

            calculateButton.Click += (s, e) => UpdateTotal();
            saveButton.Click += (s, e) => SaveInvoice();
        }

        private void UpdateTotal()
        {
            _invoice.CustomerName = customerNameTextBox.Text;
            _invoice.CustomerNumber = "KU-" + customerNoDigitsTextBox.Text;
            _invoice.Description = descriptionTextBox.Text;

            if (!int.TryParse(quantityTextBox.Text, out int qty))
            {
                MessageBox.Show("Quantity must be a valid integer.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _invoice.Quantity = qty;

            if (!decimal.TryParse(priceTextBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price))
            {
                MessageBox.Show("Price must be a valid decimal.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _invoice.PricePerUnit = price;

            if (!_validationService.ValidateRequiredString(_invoice.CustomerName)
                || !_validationService.ValidateCustomerNumber(_invoice.CustomerNumber)
                || !_validationService.ValidateRequiredString(_invoice.Description)
                || !_validationService.ValidatePositiveQuantity(_invoice.Quantity)
                || !_validationService.ValidatePrice(_invoice.PricePerUnit))
            {
                MessageBox.Show("Please correct invalid fields.", "Validation Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            decimal total = _invoice.CalculateTotalPrice();
            totalTextBlock.Text = string.Format(CultureInfo.CurrentCulture, "Total (incl. VAT): {0:C}", total);
        }

        private void SaveInvoice()
        {
            try
            {
                string content = _invoice.BuildInvoiceText();
                string path = _fileService.SaveText(content);
                MessageBox.Show($"Invoice saved to: {path}", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving invoice: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
