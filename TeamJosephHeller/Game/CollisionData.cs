
namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CollisionData
    {
        // public readonly MatrixCoord CollisionForceDirection;
        public readonly List<string> HitObjectsCollisionGroupStrings;

        public CollisionData(/*MatrixCoord collisionForceDirection, */string objectCollisionGroupString)
        {
            throw new NotImplementedException("Redo the logic");
            // this.CollisionForceDirection = collisionForceDirection;
            this.HitObjectsCollisionGroupStrings = new List<string>();
            this.HitObjectsCollisionGroupStrings.Add(objectCollisionGroupString);
        }

        public CollisionData(/* MatrixCoord collisionForceDirection, */List<string> hitObjectsCollisionGroupStrings)
        {
            throw new NotImplementedException("Redo the logic");
            // this.CollisionForceDirection = collisionForceDirection;

            this.HitObjectsCollisionGroupStrings = new List<string>();

            foreach (var str in hitObjectsCollisionGroupStrings)
            {
                this.HitObjectsCollisionGroupStrings.Add(str);
            }
        }
    }
}
