using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaWars
{
    public class PlayerShip : Ship
    {
        private static readonly char[,] playerShipBody = new char[,] { { '@' }, { '@' } };
        private static readonly MatrixCoord defaultPlayerSpeed = new MatrixCoord(0, 0);
        private static readonly MatrixCoord bulletSpeed = new MatrixCoord(-1, 0);

        public PlayerShip(int col)
            : base(new MatrixCoord(GameBorder.WorldRows - playerShipBody.GetUpperBound(0) - 1, col), playerShipBody, defaultPlayerSpeed)
        {
        }

        public override MovingObject Fire()
        {
            return new Bullet(this.TopLeft, bulletSpeed);
        }

        public virtual void MoveLeft()
        {
            this.topLeft.Col = this.TopLeft.Col - 1; // TODO: check logic!!! property or field - topLeft vs TopLeft
        }

        public virtual void MoveRight()
        {
            this.topLeft.Col = this.TopLeft.Col + 1; // TODO: check logic!!! property or field - topLeft vs TopLeft
        }
    }
}
