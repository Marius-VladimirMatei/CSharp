using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public class MathPuzzle
    {
        private Random rand = new Random();

        public (string, int) GeneratePuzzle()
        {
            int a = rand.Next(1, 11);
            int b = rand.Next(1, 11);
            int op = rand.Next(4);
            string question = "";
            int result = 0;

            switch (op)
            {
                case 0:
                    question = $"{a} + {b}";
                    result = a + b;
                    break;
                case 1:
                    question = $"{a} - {b}";
                    result = a - b;
                    break;
                case 2:
                    question = $"{a} * {b}";
                    result = a * b;
                    break;
                case 3:
                    // Ensure clean division, avoiding deciaml result: a must be divisible by b
                    b = rand.Next(1, 11); // Re-choose b to be sure it's not 0
                    result = rand.Next(1, 11); // the answer
                    a = result * b; // this ensures a / b = result
                    question = $"{a} / {b}";
                    break;
            }

            return (question, result);
        }
    }
}
