namespace NinjaWars
{
    using System;
    using System.Linq;

    public struct MatrixCoord
    {
        public MatrixCoord(int row, int col) : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool Equals(MatrixCoord obj)
        {
            return obj.Row == this.Row && obj.Col == this.Col;
        }

        //public override int GetHashCode()
        //{
        //    return this.Row.GetHashCode() * 7 + this.Col;
        //}
        public static MatrixCoord operator +(MatrixCoord a, MatrixCoord b)
        {
            return new MatrixCoord(a.Row + b.Row, a.Col + b.Col);
        }

        public static MatrixCoord operator -(MatrixCoord a, MatrixCoord b)
        {
            return new MatrixCoord(a.Row - b.Row, a.Col - b.Col);
        }
    }
}