namespace candlelit
{
    public class Key : PickupItem
    {
        private Door assignedDoor;

        public Door AssignedDoor { get => assignedDoor; set => assignedDoor = value; }

        public void unlockDoor() { }
    }
}