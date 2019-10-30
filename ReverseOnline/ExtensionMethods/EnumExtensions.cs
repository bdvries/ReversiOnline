using ReversiOnline.Reversi.Board;
using System;

namespace ReversiOnline.Reversi
{
    public static class EnumExtensions
    {
        public static Direction TranslateDirection(this WindDirections direction)
        {
            int horizontal = 0;
            int vertical = 0;

            switch (direction)
            {
                case WindDirections.N:
                    vertical = 1;
                    break;
                case WindDirections.E:
                    horizontal = 1;
                    break;
                case WindDirections.S:
                    vertical = -1;
                    break;
                case WindDirections.W:
                    horizontal = -1;
                    break;
                case WindDirections.NE:
                    vertical = 1;
                    horizontal = 1;
                    break;
                case WindDirections.SE:
                    vertical = -1;
                    horizontal = 1;
                    break;
                case WindDirections.NW:
                    vertical = 1;
                    horizontal = -1;
                    break;
                case WindDirections.SW:
                    vertical = -1;
                    horizontal = -1;
                    break;
                default:
                    throw new IndexOutOfRangeException("The direction is invalid.");
            }

            return new Direction(horizontal, vertical);
        }
        public static Players Negate(this Players player)
        {
            return player switch
            {
                Players.PLAYER1 => Players.PLAYER2,
                Players.PLAYER2 => Players.PLAYER1,
                Players.NONE => Players.NONE,
                _ => throw new IndexOutOfRangeException("Player is not valid."),
            };
        }
       
    }
}
