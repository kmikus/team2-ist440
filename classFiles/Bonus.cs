namespace candlelit
{
    public class Bonus : PickupItems
    {
        private float pointValue;

        public float PointValue { get => pointValue; set => pointValue = value; }

        public void addBonusPoints(Score score) { }
    }
}