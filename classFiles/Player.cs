namespace candlelit
{
    public class Player : Character
    {
        private float horizontalSpeed;
        private float jumpForce;
        private bool isGrounded;
        private Key[] keys;

        public float HorizontalSpeed { get => horizontalSpeed; set => horizontalSpeed = value; }
        public float JumpForce { get => jumpForce; set => jumpForce = value; }

        public jump() { }
        public toggleFlashlight(Flashlight flashlight) { }
    }
}