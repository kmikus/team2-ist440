namespace candlelit
{
	public class Enemy : Character
    {
        private bool isGrounded;
        private float patrolSpeed;
        private float patrolRange;
        private float damage;

        public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
        public float PatrolSpeed { get => patrolSpeed; set => patrolSpeed = value; }
        public float PatrolRange { get => patrolRange; set => patrolRange = value; }
        public float Damage { get => damage; set => damage = value; }

        public void dealDamage(Player player) { }
    }
}