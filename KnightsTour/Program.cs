using System;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            FindKnightsTourByBruteForce(5, 0, 0);
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
                var chessboard = new Chessboard(5);
                var knight = new Knight(0, 0, chessboard.Size);
                var i = 1;

                //Console.WriteLine($"{i} - starting from {knight.ActualSquare.ToString()}");
                do
                {
                    i++;
                    //Console.WriteLine($"---------------------------------------------------");

                    //Console.WriteLine($"{i} - list of possible moves:");
                    //foreach (var moves in knight.PossibleMoves)
                    //{
                    //    Console.WriteLine($"{moves}");
                    //}

                    if (knight.PossibleMoves.Count > 0)
                    {
                        var randomMove = rnd.Next(0, knight.PossibleMoves.Count - 1);
                        var selectedMove = knight.PossibleMoves[randomMove];
                        knight.ActualSquare = selectedMove;
                        //Console.WriteLine($"Selected {selectedMove}");
                        //Console.WriteLine($"possible moves: {knight.PossibleMoves.Count}");
                        //Console.WriteLine($"from {0} to {knight.PossibleMoves.Count - 1} we've got move with index {randomMove} in possible moves");
                    }
                    else
                    {
                        //Console.WriteLine("You can't do more moves");
                    }

                    //Console.WriteLine($"---------------------------------------------------");
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
