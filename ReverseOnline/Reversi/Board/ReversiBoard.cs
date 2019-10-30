using ReversiOnline.Reversi.Board;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversiOnline.Reversi
{
    public class ReversiBoard
    {
        private readonly int BOARD_SIZE = 64;
        private readonly int BOARD_WIDTH = 8;
        private readonly List<int> START_PLAYER_1 = new List<int> { 27, 36};
        private readonly List<int> START_PLAYER_2 = new List<int> { 28, 35};

        private List<Players> Board { get; set; }

        public ReversiBoard()
        {
            Board = Enumerable.Repeat(Players.NONE, BOARD_SIZE).ToList();
            START_PLAYER_1.ForEach(index => Board[index] = Players.PLAYER1);
            START_PLAYER_2.ForEach(index => Board[index] = Players.PLAYER2);
        }

        public ReversiBoard(List<Players> position)
        {
            if (position.Count == BOARD_SIZE)
            {
                Board = position;
            }
        }

        public bool TryMakeMove(int place, Players player)
        {
            var validMove = ValidateMove(place, player);

            if (validMove)
            {
                Board[place] = player;
            }

            return validMove;
        }

        public bool ValidateMove(int place, Players player)
        {
            var playerIsNone = Board[place] == Players.NONE;
            var validDirection = MoveResultsInFilledFields(place, player);

            

            // todo check if the player can make the move.
            return playerIsNone && validDirection;
        }


        private bool MoveResultsInDiskColorChanges(int place, Players player)
        {
            foreach (WindDirection windDirection in Enum.GetValues(typeof(WindDirection)))
            {
                var offset = windDirection.TranslateDirection();
                do
                {
                    place = offset.AddDirectionToCoordinate(place, BOARD_WIDTH);
                } while (Board[place] == player);

                if (Board[place] == player.Negate())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
