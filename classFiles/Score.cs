namespace candlelit
{
    public class Score
    {
        private float timerScore;
        private float bonusScore;

        public float TimerScore { get => timerScore; set => timerScore = value; }
        public float BonusScore { get => bonusScore; set => bonusScore = value; }
    }
}