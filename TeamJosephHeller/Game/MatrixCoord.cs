using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaWars
{
    public struct MatrixCoord
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public MatrixCoord(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static MatrixCoord operator +(MatrixCoord a, MatrixCoord b)
        {
            return new MatrixCoord(a.Row + b.Row, a.Col + b.Col);
        }

        public static MatrixCoord operator -(MatrixCoord a, MatrixCoord b)
        {
            return new MatrixCoord(a.Row - b.Row, a.Col - b.Col);
        }

        public bool Equals(MatrixCoord obj)
        {
            return obj.Row == this.Row && obj.Col == this.Col;
        }

        //public override int GetHashCode()
        //{
        //    return this.Row.GetHashCode() * 7 + this.Col;
        //}
    }
}
