using System;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var chessboard = new Chessboard(8);
            var knight = new Knight(4, 4, chessboard.Size);

            Console.WriteLine($"Actual position: {knight.ActualSquare}");
            Console.WriteLine($"Possible moves: ");
            foreach (var move in knight.PossibleMoves)
            {
                Console.WriteLine(move);
            }

        }
    }
}
