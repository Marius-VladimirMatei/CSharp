using System;


namespace _0401_eventManager.Services
{
    public static class InputHandler
    {
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

        public static DateTime GetDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                try
                {
                    Validation.ValidateDate(input, out DateTime date);
                    return date;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string GetEmail(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                try
                {
                    Validation.ValidateEmail(input);
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