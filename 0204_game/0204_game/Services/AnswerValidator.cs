using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public static class AnswerValidator
    {
        public static bool ValidateAnswer(int userAnswer, int correctAnswer)
        {
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct!");
                return true;
            }

            Console.WriteLine($"Wrong! The correct answer was: {correctAnswer}");
            return false;
        }
    }
}
