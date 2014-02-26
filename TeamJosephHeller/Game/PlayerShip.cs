namespace NinjaWars
{
    using System;
    using System.Linq;

    public class PlayerShip : Ship
    {
        private static readonly char[,] playerShipBody = new char[,] 
        {
            { ' ', '^', ' ' },
            { '/', '@', '\\' },
            { ' ', '\"', ' ' }
        };

        private static readonly byte initialLifes = 5;

        private static readonly MatrixCoord defaultPlayerSpeed = new MatrixCoord(0, 0);
        private static readonly MatrixCoord bulletSpeed = new MatrixCoord(-1, 0);

        private byte score;

        public PlayerShip(int col)
            : base(new MatrixCoord(GameBorder.WorldRows - playerShipBody.GetUpperBound(0) - 1, col),
                   playerShipBody,
                   defaultPlayerSpeed)
        {
            this.Lifes = initialLifes;
            this.Score = 0;
        }

        public event EventHandler OnKilled;

        public byte Lifes { get; private set; }

        public byte Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value == byte.MaxValue)
                {
                    throw new MaxScoreAchievedException("A player has achieved the maximum score possible");
                }
                else
                {
                    this.score = value;
                }
            }
        }

        public override MovingObject Fire()
        {
            return new Bullet(new MatrixCoord(this.TopLeft.Row - 1, this.TopLeft.Col + 1), bulletSpeed, this);
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

                this.OnKilled += (sender, eventInfo) =>
                {
                    Engine.Pause();
                };

                if (this.Lifes > 0)
                {
                    this.Health = InitialHealth;
                    this.IsDestroyed = false;
                }
            }
        }

        public override void Update()
        {
            base.Update();

            if (this.OnKilled != null)
            {
                this.OnKilled(this, new EventArgs());
            }

            this.OnKilled = null;
        }

        public void KillEnemy()
        {
            this.Score++;
        }

        public virtual void TakeLifes()
        {
            this.Lifes--;
        }

        public virtual void TakeHealth()
        {
            this.Health--;
        }
    }
}