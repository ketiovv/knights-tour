using System;
using System.Collections.Generic;
using System.Linq;
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

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    allSquaresOnChessboard.Add(new Square(i, j));
                }
            }

            return allSquaresOnChessboard;
        }

        public void PrintChessboardWithKnightPath(Knight knight)
        {
            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    var square = new Square(x, y);
                    Console.Write($"{knight.SquaresVisited.IndexOf(square) + 1}".PadRight(7));
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
