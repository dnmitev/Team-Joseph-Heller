namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWars.Interfaces;

    public class Engine
    {
        private const int ThreadSleepTime = 100;

        private readonly IRenderer renderer;
        private readonly IUserInterface userInterface;
        private readonly List<GameObject> allObjects;
        // List<MovingObject> movingObjects;
        // List<GameObject> staticObjects;
        private PlayerShip playerShip;

        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            // this.movingObjects = new List<MovingObject>();
            // this.staticObjects = new List<GameObject>();
        }

        //private void AddStaticObject(GameObject obj)
        //{
        //    // this.staticObjects.Add(obj);
        //    this.allObjects.Add(obj);
        //}
        //private void AddMovingObject(MovingObject obj)
        //{
        //   //  this.movingObjects.Add(obj);
        //    this.allObjects.Add(obj);
        //}

        public static void Pause()
        {
            Console.ReadKey();
        }

        public void AddPlayer(PlayerShip player)
        {
            //should we let adding a player more than once
            this.playerShip = player;
        }
        
        public virtual void MovePlayerShipLeft()
        {
            this.playerShip.MoveLeft();
        }

        public virtual void MovePlayerShipRight()
        {
            this.playerShip.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(ThreadSleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                try
                {
                    CollisionDispatcher.HandleCollisions(this.allObjects);

                    if (this.playerShip.IsDestroyed)
                    {
                        break;
                    }
                }
                catch (MaxScoreAchievedException)
                {
                    break;
                }

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);

                this.AddGameObjectsToEngine(producedObjects);
                this.AddGameObjectsToEngine(GenerateRandomObject());
            }
        }

        public void AddObject(GameObject obj)
        {
            this.allObjects.Add(obj);
        }

        public GameObject EngagePlayerWeapons()
        {
            return this.playerShip.Fire();
        }

        private static List<GameObject> GenerateRandomObject()
        {
            MatrixCoord initialCoord = new MatrixCoord(0, GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldCols - 2));

            List<GameObject> produced = new List<GameObject>();

            int objectTypeIndex = -1;

            if (GameHouseKeeping.GetProbabilityPercentage(0.5))
            {
                objectTypeIndex = 0;
            }

            if (GameHouseKeeping.GetProbabilityPercentage(5))
            {
                objectTypeIndex = 1;
            }

            if (GameHouseKeeping.GetProbabilityPercentage(10))
            {
                objectTypeIndex = 2;
            }

            if (GameHouseKeeping.GetProbabilityPercentage(0.6))
            {
                objectTypeIndex = 3;
            }

            switch (objectTypeIndex)
            {
                case 0:
                    produced.Add(new Item(initialCoord));
                    break;
                case 1:
                    produced.Add(new EnemyShip(initialCoord.Col, new MatrixCoord(GameHouseKeeping.RandomGenerator.Next(3), 0)));
                    break;
                case 2:
                    produced.Add(new Meteors(initialCoord)); //second case for meteors
                    break;
                case 3: 
                    produced.Add(new BonusLives(initialCoord));
                    break;
                default:
                    break;
            }

            return produced;
        }

        public void AddGameObjectsToEngine(List<GameObject> producedObjects)
        {
            foreach (var obj in producedObjects)
            {
                this.AddObject(obj);
            }
        }
    }
}