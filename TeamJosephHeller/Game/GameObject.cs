namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWars.Interfaces;

    public abstract class GameObject : IObjectProducer, IRenderable, ICollidable
    {
        public const string CollisionGroupString = "object";

        protected MatrixCoord topLeft;

        protected char[,] body;

        protected GameObject(MatrixCoord topLeft, char[,] body)
        {
            this.TopLeft = topLeft;

            //int imageRows = body.GetLength(0);
            //int imageCols = body.GetLength(1);

            this.body = this.CopyBodyMatrix(body);

            this.IsDestroyed = false;
        }

        public MatrixCoord TopLeft
        {
            get
            {
                return this.topLeft;
            }

            protected set
            {
                this.topLeft = value;
            }
        }

        public bool IsDestroyed { get; protected set; }

        public abstract void Update();

        public virtual List<MatrixCoord> GetCollisionProfile()
        {
            List<MatrixCoord> profile = new List<MatrixCoord>();

            int bodyRows = this.body.GetLength(0);
            int bodyCols = this.body.GetLength(1);

            for (int row = 0; row < bodyRows; row++)
            {
                for (int col = 0; col < bodyCols; col++)
                {
                    profile.Add(new MatrixCoord(row + this.topLeft.Row, col + this.topLeft.Col));
                }
            }

            return profile;
        }

        public abstract void RespondToCollision(ICollidable collideWith);

        public virtual bool CanCollideWith(string otherCollisionGroupString)
        {
            return GameObject.CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString()
        {
            return GameObject.CollisionGroupString;
        }

        public virtual MatrixCoord GetTopLeft()
        {
            return this.TopLeft;
        }

        public virtual char[,] GetImage()
        {
            return this.CopyBodyMatrix(this.body);
        }

        public virtual IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        private char[,] CopyBodyMatrix(char[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrixToCopy[row, col];
                }
            }

            return result;
        }

        MatrixCoord IRenderable.GetTopLeft()
        {
            return this.topLeft;
        }

        IEnumerable<GameObject> IObjectProducer.ProduceObjects()
        {
            throw new NotImplementedException();
        }

        List<MatrixCoord> ICollidable.GetCollisionProfile()
        {
            throw new NotImplementedException();
        }
    }
}