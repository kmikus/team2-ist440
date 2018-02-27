namespace candlelit
{
    public class Flashlight
    {
        private float energy;
        private bool isLightOn;

        public float Energy { get => energy; set => energy = value; }
        public bool IsLightOn { get => isLightOn; set => isLightOn = value; }

        public void toggleLight() { }
    }
}