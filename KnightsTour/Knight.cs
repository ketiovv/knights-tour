using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTour
{
    public class Knight
    {
        private Square _actualSquare;

        public Square ActualSquare
        {
            get => _actualSquare;
            set
            {
                if (_actualSquare != null)
                {
                    SquaresVisited.Add(_actualSquare);
                }
                _actualSquare = value;
                //TODO: refactor this for flexibility with size
                PossibleMoves = GeneratePossibleMoves(_actualSquare);
            }
        }

        public List<Square> PossibleMoves { get; set; }
        public List<Square> SquaresVisited { get; set; } = new List<Square>();
        public int ChessboardSize { get; set; }



        public Knight(int startingX, int startingY, int chessboardSize)
        {
            ChessboardSize = chessboardSize;
            ActualSquare = new Square(startingX, startingY);
            PossibleMoves = GeneratePossibleMoves(ActualSquare);
        }

        public List<Square> GeneratePossibleMoves(Square actualSquare)
        {
            var possibleMoves = new List<Square>
            {
                new Square(actualSquare.X + 2, actualSquare.Y + 1),
                new Square(actualSquare.X + 2, actualSquare.Y - 1),

                new Square(actualSquare.X - 2, actualSquare.Y + 1),
                new Square(actualSquare.X - 2, actualSquare.Y - 1),

                new Square(actualSquare.X + 1, actualSquare.Y + 2),
                new Square(actualSquare.X - 1, actualSquare.Y + 2),

                new Square(actualSquare.X + 1, actualSquare.Y - 2),
                new Square(actualSquare.X - 1, actualSquare.Y - 2)
            };
            var impossibleMoves =
                possibleMoves.Where(square =>
                                        square.X < 0 || square.X > ChessboardSize - 1 ||
                                        square.Y < 0 || square.Y > ChessboardSize - 1 ||
                                        SquaresVisited.Contains(square)).ToList();


            foreach (var square in impossibleMoves)
            {
                possibleMoves.Remove(square);
            }

            return possibleMoves;
        }

        public void PrintPath()
        {
            Console.WriteLine("----");
            Console.WriteLine($"Path of knight: ");

            for (var i = 0; i < SquaresVisited.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SquaresVisited[i]}");
            }

            Console.WriteLine("----");
        }
    }
}
