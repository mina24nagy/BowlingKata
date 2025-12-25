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
            for (int i = 0; i < maxRolls - 1; i++)
            {
                if (i + 1 < maxRolls && rolls[i] + rolls[i + 1] == 10) // Spare
                {
                    if (i + 2 < maxRolls)
                        score += rolls[i + 2];
                }
                score += rolls[i];
			}
			return score;
        }
    }
}