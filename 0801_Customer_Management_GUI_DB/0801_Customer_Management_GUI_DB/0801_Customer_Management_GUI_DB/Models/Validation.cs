using System;
using System.Text.RegularExpressions;

namespace _0801_Customer_Management_GUI_DB.Models
{
    public static class Validation
    {
        // Timeout for regex operations to prevent long-running matches
        private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            try
            {
                return Regex.IsMatch(email, pattern, RegexOptions.None, RegexTimeout);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNotEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool IsValidZip(string zip)
        {
            if (string.IsNullOrWhiteSpace(zip))
                return false;

            const string pattern = @"^\d{4,5}$";
            try
            {
                return Regex.IsMatch(zip, pattern, RegexOptions.None, RegexTimeout);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidHouseNumber(string houseNumber)
        {
            if (string.IsNullOrWhiteSpace(houseNumber))
                return false;
            const string pattern = @"^\d+[a-zA-Z]?$"; // Allows numbers with an optional letter suffix
            try
            {
                return Regex.IsMatch(houseNumber, pattern, RegexOptions.None, RegexTimeout);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}