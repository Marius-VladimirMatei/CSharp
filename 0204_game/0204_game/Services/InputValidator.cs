using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public static class InputValidator
    {
        public static int GetValidatedNumber(int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write("Your answer: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number) && number >= min && number <= max)
                    return number;

                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }
    }
}
