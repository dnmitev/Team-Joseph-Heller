namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWars.Interfaces;
    using System.Threading;

    public class Engine
    {
        private const int ThreadSleepTime = 100;

        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        // List<MovingObject> movingObjects;
        // List<GameObject> staticObjects;
        PlayerShip playerShip;

        public void AddPlayer(PlayerShip player)
        {
            //should we let adding a player more than once
            this.playerShip = player;
        }
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

        //public virtual void AddObject(GameObject obj)
        //{
        //    if (obj is MovingObject)
        //    {
        //        this.AddMovingObject(obj as MovingObject);
        //    }
        //    else
        //    {
        //        if (obj is PlayerShip)
        //        {
        //            AddPlayerShip(obj);
        //        }
        //        else
        //        {
        //            this.AddStaticObject(obj);
        //        }
        //    }
        //}

        //private void AddPlayerShip(GameObject obj)
        //{
        //    //TODO: we should remove the previous PlayerShip from this.allObjects
        //    this.playerShip = obj as PlayerShip;
        //    //this.AddStaticObject(obj);
        //}

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
                this.playerShip.OnKilled += (sender, eventInfo) =>
                {
                    this.Pause();
                };
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(ThreadSleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.allObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                // this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                // this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
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

        public void Pause()
        {
            Console.WriteLine("killed");
            Thread.Sleep(100);
        }
    }
}
