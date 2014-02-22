using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinjaWars;

namespace NinjaWars.Interfaces
{
    public interface IRenderable
    {
        MatrixCoord GetTopLeft();

        char[,] GetImage();
    }
}
