namespace candlelit
{
    public abstract class Character
    {
        private float health = 100f;

        public float Health { get => health; set => health = value; }

        public void flip() { }
        public void move() { }

    }
}
