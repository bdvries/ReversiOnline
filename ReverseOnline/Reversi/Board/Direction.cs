using System;

namespace ReversiOnline.Reversi
{
    public class Direction
    {
        public int Horizontal { get; }
        public int Vertical { get; }

        public Direction(int horizontal, int vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public int AddDirectionToCoordinate(int coordinate, int boardSize)
        {
            // Check if the step will remain in the board size.
            if ((coordinate % boardSize == boardSize - 1 && Horizontal == 1) || (coordinate % boardSize == 0 && Horizontal == -1)
                || (coordinate < boardSize && Vertical == 1) || (coordinate >= boardSize * (boardSize - 1) && Vertical == -1))
            {
                throw new IndexOutOfRangeException("Cannot move outside the board.");
            }

            return coordinate + Vertical + 8 * Horizontal;
        }
    }
}
