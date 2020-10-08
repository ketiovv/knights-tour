using System;
using System.Collections.Generic;
using System.Text;

namespace KnightsTour
{
    public class Chessboard
    {
        public int Size { get; set; }
        public IEnumerable<Square> AllSquares { get; set; }

        public Chessboard(int size)
        {
            Size = size;
            AllSquares = GenerateChessboard(size);
        }

        public IEnumerable<Square> GenerateChessboard(int size)
        {
            var allSquaresOnChessboard = new List<Square>();

            for (var i = 1; i <= size; i++)
            {
                for (var j = 1; j <= size; j++)
                {
                    allSquaresOnChessboard.Add(new Square(i, j));
                }
            }

            return allSquaresOnChessboard;
        }
    }
}
