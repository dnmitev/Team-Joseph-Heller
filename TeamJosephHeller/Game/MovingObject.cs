using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaWars
{
    public class MovingObject : GameObject
    {
        public MatrixCoord Speed { get; protected set; }

        public MovingObject(MatrixCoord topLeft, char[,] body, MatrixCoord speed)
            : base(topLeft, body)
        {
            this.Speed = speed;
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
