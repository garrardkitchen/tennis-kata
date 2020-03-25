using System;
using Library;
using Xunit;

namespace Tests
{
    /*
        
    Requirements:
     
    1. A game is won by the first player to have won at least four points in total and at least two points more than the opponent.

    2. The running score of each game is described in a manner peculiar to tennis: scores from zero to three points 
       are described as “love”, “fifteen”, “thirty”, and “forty” respectively.

    3. If at least three points have been scored by each player, and the scores are equal, the score is “deuce”.

    4. If at least three points have been scored by each side and a player has one more point than his opponent, 
       the score of the game is “advantage” for the player in the lead.
   
    Ref: http://codingdojo.org/kata/Tennis/
   
     */

    public class GameUnitTests
    {
        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(0, 2, false)]
        [InlineData(0, 3, false)]
        [InlineData(0, 4, true)]
        [InlineData(1, 0, false)]
        [InlineData(1, 1, false)]
        [InlineData(1, 2, false)]
        [InlineData(1, 3, false)]
        [InlineData(1, 4, true)]
        [InlineData(2, 0, false)]
        [InlineData(2, 1, false)]
        [InlineData(2, 2, false)]
        [InlineData(2, 3, false)]
        [InlineData(2, 4, true)]
        [InlineData(3, 0, false)]
        [InlineData(3, 1, false)]
        [InlineData(3, 2, false)]
        [InlineData(3, 3, false)]
        [InlineData(3, 4, false)]
        [InlineData(3, 5, true)]
        [InlineData(4, 5, false)]
        [InlineData(4, 6, true)]
        public void GivenNewGame_WhenPlayerWinsMorePointsThanApponent_ThenTheyWinGame(int player1Score,
            int player2Score, bool gameWon)
        {
            // Requirement (1) above

            // arrange
            Game game = new Game();
            game.Player1Score = player1Score;
            game.Player2Score = player2Score;

            // act
            var result = game.IsGameWon();

            // assert
            Assert.Equal(gameWon, result);
        }

        [Theory]
        [InlineData(0, 0, "love - love")]
        [InlineData(0, 1, "love - fifteen")]
        [InlineData(0, 2, "love - thirty")]
        [InlineData(1, 0, "fifteen - love")]
        [InlineData(1, 1, "fifteen - fifteen")]
        [InlineData(1, 2, "fifteen - thirty")]
        [InlineData(2, 0, "thirty - love")]
        [InlineData(2, 1, "thirty - fifteen")]
        [InlineData(2, 2, "thirty - thirty")]
        [InlineData(3, 0, "fourty - love")]
        [InlineData(3, 1, "fourty - fifteen")]
        [InlineData(3, 2, "fourty - thirty")]
        [InlineData(0, 3, "love - fourty")]
        [InlineData(1, 3, "fifteen - fourty")]
        [InlineData(2, 3, "thirty - fourty")]
        [InlineData(3, 3, "deuce - deuce")]
        [InlineData(4, 3, "advantage - deuce")]
        [InlineData(3, 4, "deuce - advantage")]
        [InlineData(5, 4, "advantage - deuce")]
        [InlineData(4, 5, "deuce - advantage")]
        public void GivenNewGame_WhenPointsWon_ThenCheckDescription(int player1, int player2, string expected)
        {
            // Requirement 2-4 above

            // arrange
            Game game = new Game();
            game.Player1Score = player1;
            game.Player2Score = player2;

            // act
            var result = game.GetScoreDescription();

            // assert
            Assert.Equal(expected, result);
        }
    }
}