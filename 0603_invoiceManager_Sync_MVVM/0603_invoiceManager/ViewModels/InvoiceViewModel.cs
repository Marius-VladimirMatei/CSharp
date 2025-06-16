using System;
using System.Windows;
using System.Windows.Input;
using _0603_invoiceManager_Sync_MVVM.Helpers;
using _0603_invoiceManager_Sync_MVVM.Models;
using _0603_invoiceManager_Sync_MVVM.Services;

namespace _0603_invoiceManager_Sync_MVVM.ViewModels
{
    // ViewModel for the main window:
    // - Implements MVVM data binding
    // - Calculates total price including 20% VAT
    // - Saves invoice to a .txt file
    public class InvoiceViewModel : BaseViewModel
    {
        // Instance Invoice model
        private readonly Invoice _invoice = new Invoice();

        // Calculated total price
        private decimal _totalPrice;

        // Keeping the digits-only customer number
        private string _customerNumberDigits;

        // Fixed company name from the model
        public string CompanyName => _invoice.CompanyName;

        // Customer name binding 
        // The setter calls OnPropertyChanged to notify the UI of changes then WPF sees the PorpertyChanged event and updates the UI accordingly.
        public string CustomerName
        {
            get { return _invoice.CustomerName; }
            set
            {
                if (_invoice.CustomerName != value)
                {
                    _invoice.CustomerName = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }

        // The user types only digits here; we prepend "KU-" in the setter 
        public string CustomerNumberDigits
        {
            get { return _customerNumberDigits; }
            set
            {
                if (_customerNumberDigits != value)
                {
                    _customerNumberDigits = value;
                    // build the full customer number with prefix
                    _invoice.CustomerNumber = "KU-" + value;
                    // notify both fields so the UI stays in sync
                    OnPropertyChanged(nameof(CustomerNumberDigits));
                    OnPropertyChanged(nameof(CustomerNumber));
                }
            }
        }

        // Read-only full customer number (with "KU-") for validation/display
        public string CustomerNumber => _invoice.CustomerNumber;

        // Product description binding (requirement A.iv)
        public string Description
        {
            get { return _invoice.Description; }
            set
            {
                if (_invoice.Description != value)
                {
                    _invoice.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        // Quantity binding 
        public int Quantity
        {
            get { return _invoice.Quantity; }
            set
            {
                if (_invoice.Quantity != value)
                {
                    _invoice.Quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        // Price per unit binding 
        public decimal PricePerUnit
        {
            get { return _invoice.PricePerUnit; }
            set
            {
                if (_invoice.PricePerUnit != value)
                {
                    _invoice.PricePerUnit = value;
                    OnPropertyChanged(nameof(PricePerUnit));
                }
            }
        }

        // Computed total price including 20% VAT
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            private set { SetProperty(ref _totalPrice, value); }
        }

        // Commands bound to the Calculate and Save buttons
        public ICommand CalculateCommand { get; }
        public ICommand SaveCommand { get; }

        public InvoiceViewModel()
        {
            // Initialize commands 
            CalculateCommand = new RelayCommand(UpdateTotalPrice);
            SaveCommand = new RelayCommand(SaveInvoice);
        }

        // Executes when the user clicks "Calculate"
        // - Validates all inputs
        // - Calls the model to compute VAT-inclusive total
        private void UpdateTotalPrice()
        {
            // run through all validation rules
            bool valid =
                ValidationService.ValidateRequiredString(CustomerName) &&     // name not empty
                ValidationService.ValidateCustomerNumber(CustomerNumber) &&   // KU- plus digits
                ValidationService.ValidateRequiredString(Description) &&      // description not empty
                ValidationService.ValidatePositiveQuantity(Quantity) &&       // quantity > 0
                ValidationService.ValidatePrice(PricePerUnit);                // price > 0

            if (!valid)
            {
                MessageBox.Show( 
                    "Please correct invalid fields.",
                    "Validation Failed",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            // compute and update the total price
            TotalPrice = _invoice.CalculateTotalPrice();
            MessageBox.Show(
                $"Total price (incl. VAT): {TotalPrice:C}",
                "Calculation Complete",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        // Executes when the user clicks "Save"
        // - Builds a formatted invoice string
        // - Uses FileService to write it to a .txt file
        private void SaveInvoice()
        {
            try
            {
                // build the invoice content with correct formatting 
                string content =
                    $"Company: {CompanyName}\n" +
                    $"Customer: {CustomerName} ({CustomerNumber})\n" +
                    $"Product: {Description}\n" +
                    $"Quantity: {Quantity}\n" +
                    $"Unit Price: {PricePerUnit:C}\n" +
                    $"Total (incl. VAT): {TotalPrice:C}\n";

                // save to .txt via service 
                string filePath = FileService.SaveAsTxt(content);

                MessageBox.Show(
                    $"Invoice saved to {filePath}",
                    "Saved",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error saving invoice: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
