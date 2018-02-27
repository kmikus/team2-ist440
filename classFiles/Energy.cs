namespace candlelit
{
    public class Energy : PickupItem
    {
        private float amount;

        public float Amount { get => amount; set => amount = value; }

        public void increaseEnergy(Flashlight f) { }
    }
}