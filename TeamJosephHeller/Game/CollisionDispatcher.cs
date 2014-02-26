namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CollisionDispatcher
    {
        public static void HandleCollisions(List<GameObject> produced)
        {
            var usedSpace = new Dictionary<MatrixCoord, GameObject>();

            foreach (var item in produced)
            {
                foreach (var coord in item.GetCollisionProfile())
                {
                    if (usedSpace.ContainsKey(coord))
                    {
                        //handle collision
                        item.RespondToCollision(usedSpace[coord]);
                        usedSpace[coord].RespondToCollision(item);
                    }
                    else
                    {
                        usedSpace.Add(coord, item);
                    }
                }
            }
        }
    }
}