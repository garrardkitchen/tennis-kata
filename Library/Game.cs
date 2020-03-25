using System;

namespace Library
{
    public class Game
    {
        private string[] scoreNames = new[] {"love", "fifteen", "thirty", "fourty"};
        public int Player1Score { get; set; } = 0;
        public int Player2Score { get; set; } = 0;
        public Game()
        {
        }

        public bool IsGameWon()
        {
            return ((Player1Score > 3) || ( Player2Score > 3)) && 
                   ((Player1Score > (Player2Score+1)) || ((Player1Score+1) < Player2Score));
        }

        public string GetScoreDescription()
        {
            if (Player1Score > 3 || Player2Score > 3)
            {
                if (Player1Score+1 == Player2Score) return $"deuce - advantage";
                if (Player1Score == Player2Score+1) return $"advantage - deuce";
            }
            
            if (Player1Score == 3 && Player2Score == 3) return $"deuce - deuce";
            
            return $"{scoreNames[Player1Score]} - {scoreNames[Player2Score]}";
        }
    }
}