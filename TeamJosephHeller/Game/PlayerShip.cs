using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaWars
{
    public class PlayerShip : Ship
    {
        private static readonly char[,] playerShipBody = new char[,] { { '@' } };
        private static readonly MatrixCoord defaultPlayerSpeed = new MatrixCoord(0, 0);

        public PlayerShip(MatrixCoord topLeft)
            : base(topLeft, playerShipBody, defaultPlayerSpeed)
        {
        }

        public override MovingObject Fire()
        {
            throw new NotImplementedException();
        }

        public virtual void MoveLeft()
        {
            this.TopLeft.Col--;
        }

        public virtual void MoveRight()
        {
            this.TopLeft.Col++;
        }
    }
}
