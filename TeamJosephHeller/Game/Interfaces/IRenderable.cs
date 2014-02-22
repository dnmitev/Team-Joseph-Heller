namespace NinjaWars.Interfaces
{
    using System;

    public interface IRenderable
    {
        MatrixCoord GetTopLeft();

        char[,] GetImage();
    }
}
