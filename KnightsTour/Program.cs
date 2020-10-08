using System;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            FindKnightsTourByBruteForce(8, 4, 4);
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

                if (knight.SquaresVisited.Count == 64)
                {
                    allSquaresVisited = true;

                    Console.WriteLine("----");

                    Console.WriteLine($"Actual position: {knight.ActualSquare}");

                    Console.WriteLine($"Possible moves: ");
                    foreach (var move in knight.PossibleMoves)
                    {
                        Console.WriteLine(move);
                    }

                    Console.WriteLine($"Visited squares: ");
                    for (var i = 0; i < knight.SquaresVisited.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {knight.SquaresVisited[i]}");
                    }

                    Console.WriteLine("----");
                }
            }
        }
    }
}
