using System.Collections.Generic;

namespace ReversiOnline.Reversi
{
    public class Game
    {
        public List<int> Board { get; private set; }
        public int ScorePlayer1 { get; private set; }
        public int ScorePlayer2 { get; private set; }

        public Game()
        {
            Board = CreateEmptyBoard();
            ScorePlayer1 = 2;
            ScorePlayer2 = 2;
        }

        public Game(List<int> board, int scorePlayer1, int scorePlayer2)
        {
            Board = board;
            ScorePlayer1 = scorePlayer1;
            ScorePlayer2 = scorePlayer2;
        }

        private List<int> CreateEmptyBoard()
        {

            

            return board;
        }
    }
}
