using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public static class Menu
    {
        public static int ShowPuzzleCategoryMenu()
        {
            Console.WriteLine("\nChoose puzzle category:");
            Console.WriteLine("1. Mathematical");
            Console.WriteLine("2. Logical");
            Console.WriteLine("3. Exit");

            return InputValidator.GetValidatedNumber(1, 3);
        }
    }


}
