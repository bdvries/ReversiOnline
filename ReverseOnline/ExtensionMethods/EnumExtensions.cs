using ReversiOnline.Reversi.Board;
using System;

namespace ReversiOnline.Reversi
{
    public static class EnumExtensions
    {
        public static Direction TranslateDirection(this WindDirection direction)
        {
            int horizontal = 0;
            int vertical = 0;

            switch (direction)
            {
                case WindDirection.N:
                    vertical = 1;
                    break;
                case WindDirection.E:
                    horizontal = 1;
                    break;
                case WindDirection.S:
                    vertical = -1;
                    break;
                case WindDirection.W:
                    horizontal = -1;
                    break;
                case WindDirection.NE:
                    vertical = 1;
                    horizontal = 1;
                    break;
                case WindDirection.SE:
                    vertical = -1;
                    horizontal = 1;
                    break;
                case WindDirection.NW:
                    vertical = 1;
                    horizontal = -1;
                    break;
                case WindDirection.SW:
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
