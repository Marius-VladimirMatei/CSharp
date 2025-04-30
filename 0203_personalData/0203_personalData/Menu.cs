using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0203_personalData
{
    // Class designed to hold the menu
    public static class Menu
    {
        public static void ShowMenu()
        {
            Console.WriteLine("=== Person Manager ===");
            Console.WriteLine("1. Create a person");
            Console.WriteLine("2. Display people by age");
            Console.WriteLine("3. Display all entries");
            Console.WriteLine("4. Exit");
        }

        public static string GetChoice()
        {
            Console.Write("Select an option (1-4): ");
            return Console.ReadLine();
        }
    }
}
