namespace candlelit
{
    public class Health : PickupItem
    {
        private float health;

        public float Health { get => health; set => health = value; }

        public void increaseHealth(Player player) { }
    }
}