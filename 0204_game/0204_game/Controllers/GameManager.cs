
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public class GameManager
    {
        private ScoreManager scoreManager = new ScoreManager();
        private PuzzleManager puzzleManager = new PuzzleManager();

        public void RunGameLoop()
        {
            Console.WriteLine("Welcome to BrainTech Games!");
            Console.WriteLine("Solve puzzles to earn points. Good luck!");

            while (true)
            {
                int choice = Menu.ShowPuzzleCategoryMenu();

                if (choice == 3)
                    break; // Exit the game

                bool isCorrect = false;

                if (choice == 1)
                    isCorrect = puzzleManager.PlayMathPuzzle();
                else if (choice == 2)
                    isCorrect = puzzleManager.PlayLogicPuzzle();

                if (isCorrect)
                    scoreManager.AddPoints(2);
                else
                    scoreManager.DeductPoints(1);

                Console.WriteLine($"\nCurrent Score: {scoreManager.TotalScore}");
            }

            Console.WriteLine($"\nFinal Score: {scoreManager.TotalScore}");
            Console.WriteLine("Thank you for playing!");
        }
    }

}
