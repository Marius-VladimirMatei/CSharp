using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0204_game
{
    public class ScoreManager
    {
        public int TotalScore { get; private set; } = 0;

        public void AddPoints(int points)
        {
            TotalScore += points;
        }

        public void DeductPoints(int points)
        {
            TotalScore -= points;
        }
    }

}