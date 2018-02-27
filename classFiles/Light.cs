namespace candlelit
{
    public class Light : EnvObj
    {
        private bool on;
        private float radiance;

        public bool On { get => on; set => on = value; }
        public float Radiance { get => radiance; set => radiance = value; }

        public void toggleOn() { }
    }
}