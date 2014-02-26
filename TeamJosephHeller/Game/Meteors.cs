namespace NinjaWars
{
    using NinjaWars.Interfaces;

    public class Meteors : MovingObject
    {
        public new const string CollisionGroupString = "meteor";

        private static readonly char[,] meteorBody = new char[,] { { '*' } };

        private static readonly MatrixCoord defaultMeteorSpeed = new MatrixCoord(1, 1);

        protected char[,] Body { get; set; }

        private uint damage;

        public Meteors(MatrixCoord topLeft, uint damage = 3) : base(topLeft, meteorBody, defaultMeteorSpeed)
        {
            this.Damage = damage;
        }

        public virtual uint Damage
        {
            get
            {
                return this.damage;
            }

            protected set
            {
                this.damage = value;
            }
        }

        public GameObject FiredBy { get; private set; }

        public override void RespondToCollision(ICollidable collideWith)
        {
            switch (collideWith.GetCollisionGroupString())
            {
                case "ship":
                    this.IsDestroyed = true;
                    break;
                case "meteor":
                    this.IsDestroyed = true;
                    break;
                case "bullet":
                    this.IsDestroyed = true;
                    break;
                default:
                    break;
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}