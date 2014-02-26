namespace NinjaWars
{
    using System;
    using NinjaWars.Interfaces;

    public class GameBorder : IRenderable
    {
        public const int WorldRows = 35;
        public const int WorldCols = 60;

        public MatrixCoord GetTopLeft()
        {
            return new MatrixCoord(0, 0);
        }

        public char[,] GetImage()
        {


            return GameBorder.DrawBorder(WorldRows, WorldCols);
        }

        public static char[,] DrawBorder(int height, int width)
        {
            char[,] image = new char[height + 2, width + 2];
            for (int i = 1; i < width + 1; i++)
            {
                image[0, i] = '_';
                image[height + 1, i] = '_';
            }

            for (int i = 1; i < height + 1; i++)
            {
                image[i, 0] = '|';
                image[i, width + 1] = '|';
            }

            return image;
        }
    }
}
