namespace NinjaWars
{
    using System;
    using System.Linq;

    internal class BonusLives : Item
    {
        public new const string CollisionGroupString = "life";

        private static readonly char[,] defaultItemBody = new char[,] { { (char)2 } };

        private static readonly MatrixCoord defaultItemSpeed = new MatrixCoord(1, 0);

        private int addLives = 0;

        public BonusLives(MatrixCoord topLeft, int addLives = 1) : base(topLeft)
        {
            this.AddLives = addLives;
        }

        public virtual int AddLives
        {
            get
            {
                return this.addLives;
            }

            private set
            {
                this.addLives = value;
            }
        }

        public GameObject FiredBy { get; private set; }

        protected char[,] Body { get; private set; }

        public override void RespondToCollision(Interfaces.ICollidable collideWith)
        {
            if (collideWith.GetCollisionGroupString() == "ship")
            {
                this.AddLives++;// i think this is wrong
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}