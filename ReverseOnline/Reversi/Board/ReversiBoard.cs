using System.Collections.Generic;
using System.Linq;

namespace ReversiOnline.Reversi
{
    public class ReversiBoard
    {
        private readonly int BOARD_SIZE = 64;
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

        public bool MakeMove(int place, Players player)
        {
            var validMove = Validatemove(place, player);

            if (validMove)
            {
                Board[place] = player;
            }

            return validMove;
        }

        public bool Validatemove(int place, Players player)
        {
            var validMove = Board[place] == Players.NONE;
            
            // todo check if the player can make the move.
            return ;
        }

        public bool CheckDirection(int place, Players player, Direction direction)
        {
            if ()
            {

            }
            return false;
        }
    }
}
