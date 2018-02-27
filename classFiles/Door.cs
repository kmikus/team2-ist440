namespace candlelit
{
    public class Door : EnvObj
    {
        private bool isLocked;
        private string doorText;

        public Transform teleportDest;
        public Transform cameraDest;

        public bool IsLocked { get => isLocked; set => isLocked = value; }
        public string DoorText { get => doorText; set => doorText = value; }

        public void transport() { }
    }
}