namespace NinjaWars.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoord> GetCollisionProfile();

        void RespondToCollision(ICollidable colidedWith);

        string GetCollisionGroupString();
    }
}
