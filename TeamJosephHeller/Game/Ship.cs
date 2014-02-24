namespace NinjaWars
{
    using System;
    using NinjaWars.Interfaces;

    public abstract class Ship : MovingObject
    {
        public new const string CollisionGroupString = "ship";

        protected const int InitialHealth = 5;
        protected const int BulletSpeed = 1;

        public Ship(MatrixCoord topLeft, char[,] body, MatrixCoord speed)
            : base(topLeft, body, speed)
        {
            this.Health = InitialHealth;
        }

        public virtual uint Health { get; protected set; }

        public virtual void TakeDamage(uint damage)
        {
            this.Health -= damage;
            if (this.Health == 0) this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
        public abstract MovingObject Fire();

        public override void RespondToCollision(ICollidable collideWith)
        {
            switch (collideWith.GetCollisionGroupString())
            {
                case "ship": this.IsDestroyed = true; break;
                case "bullet": this.TakeDamage((collideWith as Bullet).Damage); break;
                  case "meteor": this.TakeDamage((collideWith as Meteors).Damage); break;
                default: break;
            }
        }
    }
}
