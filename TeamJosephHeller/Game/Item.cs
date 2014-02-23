namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Item : MovingObject
    {
        public new const string CollisionGroupString = "item";

        private static readonly char[,] defaultItemBody = new char[,] { { 'I' } };

        private static readonly MatrixCoord defaultItemSpeed = new MatrixCoord(1, 0);


        public Item(MatrixCoord topLeft)
            : base(topLeft, defaultItemBody, defaultItemSpeed)
        {
        }

        public override void RespondToCollision(Interfaces.ICollidable collideWith)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}