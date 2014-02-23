namespace NinjaWars
{
    using System;
    using System.Linq;
    using System.Threading;

    public class PlayerShip : Ship
    {
        private static readonly char[,] playerShipBody = new char[,] 
        { 
            { ' ','^',' ' }, 
            { '/','@','\\' },
            { ' ','\"',' '}
        };
        private static readonly byte  initialLifes = 5;

        private static readonly MatrixCoord defaultPlayerSpeed = new MatrixCoord(0, 0);
        private static readonly MatrixCoord bulletSpeed = new MatrixCoord(-1, 0);

        public PlayerShip(int col)
            : base(
                    new MatrixCoord(GameBorder.WorldRows - playerShipBody.GetUpperBound(0) - 1, col),
                    playerShipBody,
                    defaultPlayerSpeed)
        {
            this.Lifes = initialLifes;
        }

        public event EventHandler OnKilled;
        //{
        //    add
        //    {
        //        // First try to remove the handler, then re-add it
        //        OnKilled -= value;
        //        OnKilled += value;
        //    }

        //    remove
        //    {
        //        OnKilled -= value;
        //    }
        //}

        public byte Lifes { get; private set; }

        public override MovingObject Fire()
        {
            return new Bullet(new MatrixCoord(this.TopLeft.Row - 1, this.TopLeft.Col + 1), bulletSpeed);
        }

        public virtual void MoveLeft()
        {
            this.topLeft.Col = this.TopLeft.Col - 1; // TODO: check logic!!! property or field - topLeft vs TopLeft
        }

        public virtual void MoveRight()
        {
            this.topLeft.Col = this.TopLeft.Col + 1; // TODO: check logic!!! property or field - topLeft vs TopLeft
        }

        public override void RespondToCollision(Interfaces.ICollidable collideWith)
        {
            base.RespondToCollision(collideWith);
            if (this.IsDestroyed)
            {
                this.Lifes--;

                if (this.OnKilled != null)
                {
                    this.OnKilled(this, new EventArgs());
                }

                if (this.Lifes > 0)
                {
                    this.Health = InitialHealth;
                    this.IsDestroyed = false;  
                }
            }
        }
    }
}
