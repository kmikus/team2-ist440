namespace candlelit
{
    public class EnvObj
    {
        private bool playerPassThrough;
        private bool doesHurtPlayer;
        private bool destructable;

        public bool PlayerPassThrough { get => playerPassThrough; set => playerPassThrough = value; }
        public bool DoesHurtPlayer { get => doesHurtPlayer; set => doesHurtPlayer = value; }
        public bool Destructable { get => destructable; set => destructable = value; }
    }
}