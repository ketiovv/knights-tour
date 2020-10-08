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

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
