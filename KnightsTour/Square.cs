using System;
using System.Collections.Generic;
using System.Text;

namespace KnightsTour
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Square(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X},{Y})";

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Square);
        }

        public bool Equals(Square sq)
        {
            if (ReferenceEquals(sq, null))
                return false;

            if (ReferenceEquals(this, sq))
                return true;

            if (this.GetType() != sq.GetType())
                return false;

            return X == sq.X && Y == sq.Y;
        }
    }
}
