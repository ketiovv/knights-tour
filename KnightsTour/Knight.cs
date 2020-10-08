using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTour
{
    public class Knight
    {
        public Square ActualSquare { get; set; }
        public List<Square> PossibleMoves { get; set; } = new List<Square>();
        public List<Square> SquaresVisited { get; set; } = new List<Square>();

        public Knight(int startingX, int startingY, int chessboardSize)
        {
            ActualSquare = new Square(startingX, startingY);
            PossibleMoves = GeneratePossibleMoves(ActualSquare, chessboardSize);
        }

        public List<Square> GeneratePossibleMoves(Square actualSquare, int chessboardSize)
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
                                        square.X < 0 || square.X > chessboardSize ||
                                        square.Y < 0 || square.Y > chessboardSize).ToList();


            foreach (var square in impossibleMoves)
            {
                possibleMoves.Remove(square);
            }


            return possibleMoves;
        }
    }
}
