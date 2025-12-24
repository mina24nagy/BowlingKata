namespace BowlingGame
{
    public class BowlingGame
	{
        int score = 0;
        public void Roll(int pins)
        {
            score += pins;
        }

        public int Score()
        {
            return score;
        }
    }
}