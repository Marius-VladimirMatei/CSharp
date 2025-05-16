using System;


namespace _0301_persAddress.Services
{
    public class InputHandler
    {   
        public static string GetName(string prompt)
        {
            while (true)
            {
                // Prompt the user for input+
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim(); // Read the input and trim whitespace
                try
                {
                    // Validate the input using the Validation class
                    Validation.ValidateName(input);
                    return input;
                }
                // Catch any exceptions thrown by the validation
                catch (Exception ex)
                {
                    // Display the error message
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string GetText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                try
                {
                    Validation.ValidateText(input);
                    return input;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string GetPostalCode(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                try
                {
                    Validation.ValidatePostalCode(input);
                    return input;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string GetPhone(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                try
                {
                    Validation.ValidatePhone(input);
                    return input;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
