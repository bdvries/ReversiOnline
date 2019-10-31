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

        public List<Players> Board { get; private set; }

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

        // Returns 0 on failure.
        public int TryMakeMove(int place, Players player)
        {
            var disksToChange = new List<int>();

            if (Board[place] == Players.NONE)
            {
                disksToChange = DisksToChangeForMove(place, player);

                if (disksToChange.Count != 0)
                {
                    ApplyMove(disksToChange, place, player);
                }
            }

            return disksToChange.Count;
        }

        public bool ValidateMove(int place, Players player)
        {
            var disksToChange = new List<int>();
            var playerIsNone = Board[place] == Players.NONE;

            if (playerIsNone)
            {
                disksToChange = DisksToChangeForMove(place, player);
            }

            return disksToChange.Count != 0;
        }

        private void ApplyMove(List<int> disksToChagne, int place, Players player)
        {
            disksToChagne.ForEach(index => Board[index] = player);
            Board[place] = player;
        }

        private List<int> DisksToChangeForMove(int place, Players player)
        {
            List<int> disksToChange = new List<int>();

            foreach (WindDirection windDirection in Enum.GetValues(typeof(WindDirection)))
            {
                disksToChange.AddRange(DisksToChangeForDirection(place, player, windDirection));
            }

            return disksToChange;
        }

        // Wrapper for the recursion.
        private List<int> DisksToChangeForDirection(int place, Players player, WindDirection windDirection)
        {
            var result = new List<int>();
            DisksToChangeForDirection(place, player, windDirection, result);

            return result;
        }

        private bool DisksToChangeForDirection(int place, Players player, WindDirection direction, List<int> disksToChange)
        {
            bool directionIsValid;
            place = direction.TranslateDirection()
                    .AddDirectionToCoordinate(place, BOARD_WIDTH);

            // Iterate over opponents pieces
            if (Board[place] == player.Negate())
            {
                directionIsValid = DisksToChangeForDirection(place, player, direction, disksToChange);
                if (directionIsValid)
                {
                    disksToChange.Add(place);
                }                
            }
            else {
                // Return whetere there is a piece of the palyer at the end.
                directionIsValid = Board[place] == player;
            }

            return directionIsValid;
        }
    }
}
