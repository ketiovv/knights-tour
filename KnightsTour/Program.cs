using System;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            FindKnightsTourByBruteForce(6, 0, 0);
        }

        private static void FindKnightsTourByBruteForce(int chessboardSize, int startingX, int startingY)
        {
            var winner = false;
            var attempts = 0;

            while (winner == false)
            {
                attempts++;
                Console.WriteLine(attempts);
                var rnd = new Random();
                var chessboard = new Chessboard(chessboardSize);
                var knight = new Knight(startingX, startingY, chessboardSize);

                do
                {
                    if (knight.PossibleMoves.Count > 0)
                    {
                        var randomMove = rnd.Next(0, knight.PossibleMoves.Count - 1);
                        var selectedMove = knight.PossibleMoves[randomMove];
                        knight.ActualSquare = selectedMove;
                    }
                } while (knight.PossibleMoves.Count > 0);

                knight.SquaresVisited.Add(knight.ActualSquare);

                if (knight.SquaresVisited.Count == chessboard.Size * chessboard.Size)
                {
                    winner = true;
                    chessboard.PrintChessboardWithKnightPath(knight);
                    knight.PrintPath();
                }
            }
        }
    }
}
