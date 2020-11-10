using System;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var chessboard = new Chessboard(8);
            var knight = new Knight(4, 4, chessboard.Size);

            do
            {
                foreach (var moves in knight.PossibleMoves)
                {
                    Console.WriteLine($"{moves}");
                }

                knight.ActualSquare = knight.PossibleMoves[rnd.Next(0, knight.PossibleMoves.Count - 1)];
                chessboard.PrintChessboardWithKnightPath(knight);
            } while (knight.PossibleMoves.Count != 0);
            knight.PrintPath();
        }

        private static void FindKnightsTourByBruteForce(int chessboardSize, int startingX, int startingY)
        {
            var rnd = new Random();
            var chessboard = new Chessboard(chessboardSize);
            var allSquaresVisited = false;

            while (!allSquaresVisited)
            {
                var knight = new Knight(startingX, startingY, chessboard.Size);
                while (knight.PossibleMoves.Count != 0)
                {
                    knight.ActualSquare = knight.PossibleMoves[rnd.Next(0, knight.PossibleMoves.Count - 1)];
                }
                Console.WriteLine($"Visited squares count: {knight.SquaresVisited.Count}");

                if (knight.SquaresVisited.Count == chessboardSize * chessboardSize)
                {
                    allSquaresVisited = true;
                    knight.PrintPath();
                    chessboard.PrintChessboardWithKnightPath(knight);
                }
            }
        }
    }
}
