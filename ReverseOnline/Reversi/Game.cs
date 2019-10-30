using System.Collections.Generic;

namespace ReversiOnline.Reversi
{
    public class Game
    {
        public ReversiBoard Board { get; private set; }
        public int ScorePlayer1 { get; private set; }
        public int ScorePlayer2 { get; private set; }

        public Game()
        {
            Board = new ReversiBoard();
            ScorePlayer1 = 2;
            ScorePlayer2 = 2;
        }

        public Game(List<Players> board, int scorePlayer1, int scorePlayer2)
        {
            Board = new ReversiBoard(board);
            ScorePlayer1 = scorePlayer1;
            ScorePlayer2 = scorePlayer2;
        }
    }
}
