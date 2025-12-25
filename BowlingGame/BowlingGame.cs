namespace BowlingGame
{
    public class BowlingGame
	{
        static int maxRolls = 21;
		int[] rolls = new int[maxRolls];
        int thisBowlingBall = 0;

		public void Roll(int pins)
        {
            rolls[thisBowlingBall] = pins;
            thisBowlingBall++;
		}

		public int Score()
		{
			int score = 0;
			int rollIndex = 0;

			for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    // Score = 10 + next two balls
                    score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
                    rollIndex += 1; // Strike only consumes ONE ball slot
                }
                else if (IsSpare(rollIndex))
                {
                    // Score = 10 + next one ball
                    score += 10 + rolls[rollIndex + 2];
                    rollIndex += 2; // Spare consumes TWO ball slots
                }
                else // Open Frame
                {
                    score += rolls[rollIndex] + rolls[rollIndex + 1];
                    rollIndex += 2; // Normal frame consumes TWO ball slots
                }
            }
            return score;
		}

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
    }
}