namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EnemyShip : Ship
    {
        private static readonly char[,] enemyShipBody = new char[,] 
        { 
            { ' ','\"',' ' }, 
            { '\\','E','/' },
            {' ','v',' '}
        };

        private static readonly MatrixCoord defaultEnemySpeed = new MatrixCoord(0, 0);
        private static readonly MatrixCoord bulletSpeed = new MatrixCoord(1, 0);

        private const int ShootProbability = 25;

        public EnemyShip(int col)
            : base(new MatrixCoord(enemyShipBody.GetUpperBound(0), col), enemyShipBody, defaultEnemySpeed)
        {
        }

        public override MovingObject Fire()
        {
            return new Bullet(new MatrixCoord(this.TopLeft.Row + 2, this.TopLeft.Col + 1), bulletSpeed);
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            var bullet = new List<GameObject>();

            if (GameHouseKeeping.GetProbabilityPercentage(ShootProbability))
            {
                bullet.Add(this.Fire());
            }

            return bullet;
        }
    }
}
