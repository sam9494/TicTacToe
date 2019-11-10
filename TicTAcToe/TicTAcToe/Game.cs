using System.Runtime.InteropServices;
using System.Text;

namespace TicTacToe
{
    public class Game : IGame
    {
        private readonly StringBuilder _board;

        public Game(string s)
        {
            _board = new StringBuilder(s);
        }

        public char GetWinner()
        {
            return _board.Winner();
        }

        public int Move(char player)
        {
            var defaultMove = -1;
            for (var i = 0; i < 9; i++)
            {
                if (_board[i] != '-') continue;

                if (defaultMove == -1) defaultMove = i;
                var nextMoveSimulation = new GameNextMoveSimulator(_board, i, player);
                if (nextMoveSimulation.GetWinner() == player)
                    return i;
            }

            return defaultMove;
        }
    }

    public interface IGame
    {
        char GetWinner();
    }

    public class GameNextMoveSimulator : IGame
    {
        private readonly StringBuilder _simulateBoard;

        public GameNextMoveSimulator(StringBuilder board, int position, char player)
        {
            _simulateBoard = new StringBuilder(board.ToString()) {[position] = player};
        }

        public char GetWinner()
        {
            return _simulateBoard.Winner();
        }
    }

    public static class GameHelper
    {
        public static char Winner(this StringBuilder board)
        {
            for (var position = 0; position < 9; position += 3)
            {
                if (WinOrNot(position, board))
                    return board[position];
            }

            return '-';
        }

        private static bool WinOrNot(int position, StringBuilder board)
        {
            return board[position] != '-' && board[position] == board[position + 1] &&
                   board[position] == board[position + 2];
        }
    }
}