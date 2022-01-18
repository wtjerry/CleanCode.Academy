namespace bbv.Examples.Geometry
{
    using System;

    internal readonly struct Point : IEquatable<Point>
    {
        internal Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        internal int X { get; }

        internal int Y { get; }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
}