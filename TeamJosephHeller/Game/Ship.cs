using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaWars
{
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

        public virtual int Health { get; protected set; }

        public virtual void MakeDamage(int damage)
        {
            this.Health -= damage;
        }

        public abstract MovingObject Fire();
    }
}
