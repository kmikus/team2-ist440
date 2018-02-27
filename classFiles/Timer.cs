namespace candlelit
{
    public class Timer
    {
        private bool isTimeExpired;
        private float timeElapsed;
        private float timeAlotted;

        public bool IsTimeExpired { get => isTimeExpired; set => isTimeExpired = value; }
        public float TimeElapsed { get => timeElapsed; set => timeElapsed = value; }
        public float TimeAlotted { get => timeAlotted; set => timeAlotted = value; }

        public void resetTimer() { }
    }
}