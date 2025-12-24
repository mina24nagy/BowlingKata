using Shouldly;
using System.Runtime.Serialization;
namespace BowlingGame.Tests
{
    public class BowlingGameTests
	{
        BowlingGame game;
        public BowlingGameTests()
        {
			//Arrange
			game = new BowlingGame();
		}

        [Fact]
        public void RollZeroShouldReturnZero()
        {
            //Act
            game.Roll(0);

			//Assert
			game.Score().ShouldBe(0);
		}


        [Fact]
        public void OpenFrameShouldReturnSumOfPins()
        {
			//Act
			game.Roll(3);
            game.Roll(6);

			//Assert
			game.Score().ShouldBe(9);
		}

		[Theory]
		[InlineData(3, 6, 9)]
		public void OpenFrameShouldReturnSumOfPins2(int firstBall, int secondBall, int expectedScore)
		{
			//Act
			game.Roll(firstBall);
			game.Roll(secondBall);

			//Assert
			game.Score().ShouldBe(expectedScore);
		}
	}
}
