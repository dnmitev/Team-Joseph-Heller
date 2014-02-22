using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinjaWars;

namespace NinjaWars.Interfaces
{
    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoord> GetCollisionProfile();

        void RespondToCollision(ICollidable colidedWith);

        string GetCollisionGroupString();
    }
}
