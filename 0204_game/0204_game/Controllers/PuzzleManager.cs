
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public class PuzzleManager
    {
        private MathPuzzle mathPuzzle = new MathPuzzle();
        private LogicPuzzle logicPuzzle = new LogicPuzzle();

        public bool PlayMathPuzzle()
        {
            var (question, answer) = mathPuzzle.GeneratePuzzle();
            Console.WriteLine($"\nSolve: {question}");
            int userAnswer = InputValidator.GetValidatedNumber();
            return AnswerValidator.ValidateAnswer(userAnswer, answer);
        }

        public bool PlayLogicPuzzle()
        {
            var (question, options, correctIndex) = logicPuzzle.GeneratePuzzle();
            Console.WriteLine($"\n{question}");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            int userChoice = InputValidator.GetValidatedNumber(1, options.Length);
            return AnswerValidator.ValidateAnswer(userChoice - 1, correctIndex);
        }
    }
}
