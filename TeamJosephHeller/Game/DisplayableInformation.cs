namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWars.Interfaces;


    //TODO: implement messaging area in the game field where the player is notified when killed etc.
    public class DisplayableInformation : IRenderable
    {
        MatrixCoord position;

        public DisplayableInformation(MatrixCoord position)
        {
            this.position = position;
            this.Information = new List<string>();
        }

        protected List<string> Information { get; set; }

        public virtual MatrixCoord GetTopLeft()
        {
            return this.position;
        }

        public virtual char[,] GetImage()
        {
            int width = Information.Max(str => str.Length);

            char[,] image = GameBorder.DrawBorder(this.Information.Count, width);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < this.Information.Count; j++ )
                    if (i < this.Information[j].Length) image[j + 1, i + 1] = this.Information[j][i];
            }

            return image;
        }
    }
}
