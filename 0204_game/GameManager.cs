using System;

public class GameManager
{
    private ScoreManager scoreManager = new ScoreManager();
    private PuzzleManager puzzleManager = new PuzzleManager();

    public void Start()
    {
        Console.WriteLine("Welcome to BrainTech Games!");
        Console.WriteLine("Solve puzzles to earn points. Good luck!");

        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine("\nChoose puzzle category:");
            Console.WriteLine("1. Mathematical");
            Console.WriteLine("2. Logical");

            int choice = InputValidator.GetValidatedNumber(1, 2);

            bool isCorrect = false;

            if (choice == 1)
                isCorrect = puzzleManager.PlayMathPuzzle();
            else
                isCorrect = puzzleManager.PlayLogicPuzzle();

            if (isCorrect)
                scoreManager.AddPoints(2);
            else
                scoreManager.DeductPoints(1);

            Console.WriteLine($"\nCurrent Score: {scoreManager.TotalScore}");

            Console.WriteLine("\nDo you want to play another round? (y/n)");
            playAgain = Console.ReadLine()?.ToLower() == "y";
        }

        Console.WriteLine($"\nFinal Score: {scoreManager.TotalScore}");
        Console.WriteLine("Thank you for playing!");
    }
}
