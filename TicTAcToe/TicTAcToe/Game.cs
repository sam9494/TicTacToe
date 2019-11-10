using System.Runtime.InteropServices;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        public StringBuilder Board;

        public Game(string s)
        {
            Board = new StringBuilder(s);
        }

        public int Move(char player)
        {
            var defaultMove = -1;
            for (var i = 0; i < 9; i++)
            {
                if (Board[i] != '-') continue;

                if (defaultMove == -1) defaultMove = i;
                var nextMoveSimulation = new NextMoveSimulation(Board, i, player);
                var simulateBoard = nextMoveSimulation.GetBoard();
                if (simulateBoard.Winner() == player)
                    return i;
            }

            return defaultMove;
        }

        public StringBuilder GetBoard()
        {
            return Board;
        }
    }

    public class NextMoveSimulation
    {
        public StringBuilder SimulateBoard;

        public NextMoveSimulation(StringBuilder board, int position, char player)
        {
            SimulateBoard = new StringBuilder(board.ToString()) {[position] = player};
        }

        public StringBuilder GetBoard()
        {
            return SimulateBoard;
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