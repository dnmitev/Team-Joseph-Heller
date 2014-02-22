﻿using NinjaWars.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaWars
{
    public class Bullet : MovingObject
    {
        public new const string CollisionGroupString = "bullet";

        private static readonly char[,] bulletBody = new char[,] { { '|' } };

        private uint damage;

        public Bullet(MatrixCoord topLeft, MatrixCoord speed, uint damage = 1)
            : base(topLeft, bulletBody, speed)
        {
            this.Damage = damage;
        }

        public virtual uint Damage
        {
            get
            {
                return this.damage;
            }

            protected set
            {
                this.damage = value;
            }
        }

        public override void RespondToCollision(ICollidable collideWith)
        {
            switch (collideWith.GetCollisionGroupString())
            {
                case "ship": this.IsDestroyed = true; break;
                case "bullet": this.IsDestroyed = true; break;
                default: break;
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}
