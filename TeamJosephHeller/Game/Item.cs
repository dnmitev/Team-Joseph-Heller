using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaWars
{
    public class Item : MovingObject
    {
        public new const string CollisionGroupString = "item";

        private static readonly char[,] DefaultItemBody = new char[,] { { 'I' } };

        private static readonly MatrixCoord defaultItemSpeed = new MatrixCoord(0, 0);


        public Item(MatrixCoord topLeft)
            : base(topLeft, DefaultItemBody, defaultItemSpeed)
        {
        }

        public override void RespondToCollision(Interfaces.ICollidable collideWith)
        {
            throw new NotImplementedException();
        }
    }
}