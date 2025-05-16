using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public class LogicPuzzle
    {
        public (string, string[], int) GeneratePuzzle()
        {
            string question = "Which number comes next in the sequence: 2, 4, 6, 8, ?";
            string[] options = { "9", "10", "11", "12" };
            int correctAnswerIndex = 1;

            return (question, options, correctAnswerIndex);
        }
    }
}
