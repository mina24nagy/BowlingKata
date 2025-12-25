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
		[InlineData(2, 6, 8)]
		public void OpenFrameShouldReturnSumOfPins2(int firstBall, int secondBall, int expectedScore)
		{
			//Act
			game.Roll(firstBall);
			game.Roll(secondBall);

			//Assert
			game.Score().ShouldBe(expectedScore);
		}

		//[Fact(Skip = "Temp")]
		[Fact]
		public void SpareFrameShouldAddNextBallAsBonus()
		{
			//Act
			game.Roll(5);
			game.Roll(5); // Spare
			game.Roll(4);

			//Assert
			game.Score().ShouldBe(18); // 5 + 5 + 4 + 4
		}

		[Fact]
		public void NineOpenFramesThenSpareInTheTens()
		{
			//Act
			game.Roll(5);
			game.Roll(2);
			// 2nd frame
			game.Roll(4);
			game.Roll(3);
			// 3rd frame
			game.Roll(9);
			game.Roll(0);
			// 4th frame
			game.Roll(5);
			game.Roll(2);
			// 5th frame
			game.Roll(4);
			game.Roll(3);
			// 6th frame
			game.Roll(9);
			game.Roll(0);
			// 7th frame
			game.Roll(5);
			game.Roll(2);
			// 8th frame
			game.Roll(4);
			game.Roll(3);
			// 9th frame
			game.Roll(9);
			game.Roll(0);
			// 10th frame
			game.Roll(7);
			game.Roll(3);
			//// Bonus for Spare in the 10th frame
			game.Roll(1);


			//Assert
			game.Score().ShouldBe(80); 
		}
		
	}
}
