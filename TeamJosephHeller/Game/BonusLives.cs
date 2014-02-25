using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaWars
{
    class BonusLives : Item
    {
        public new const string CollisionGroupString = "life";

        private static readonly char[,] defaultItemBody = new char[,] { { (char)2 } };

        private static readonly MatrixCoord defaultItemSpeed = new MatrixCoord(1, 0);

        private int addLives = 0;

        protected char[,] Body { get; set; }

        public BonusLives(MatrixCoord topLeft, int addLives = 1)
            : base(topLeft)
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
        public override void RespondToCollision(Interfaces.ICollidable collideWith)
        {
            if (collideWith.GetCollisionGroupString() == "ship")
            {
                this.AddLives++;
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}

