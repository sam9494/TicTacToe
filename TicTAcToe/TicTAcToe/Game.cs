using System.Runtime.InteropServices;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        public StringBuilder board;

        public Game(string s)
        {
            board = new StringBuilder(s);
        }

        public Game(StringBuilder s, int position, char player)
        {
            board = new StringBuilder();
            board.Append(s);
            board[position] = player;
        }

        public int Move(char player)
        {
             // find winning move
            var defaultMove = -1;
            for (var i = 0; i < 9; i++)
            {
                if (board[i] != '-') continue;

                if(defaultMove ==-1) defaultMove = i;

                var nextMoveGame = GetNextMoveGame(i, player);
                if (nextMoveGame.Winner() == player)
                    return i;
            }

            return defaultMove;

            //// find default move
            //for (var i = 0; i < 9; i++)
            //{
            //    if (board[i] == '-')
            //        return i;
            //}

            //return -1;
        }


        private Game GetNextMoveGame(int i, char player)
        {
            return new Game(board, i, player);
        }

        public char Winner()
        {
           
            for (var boardPosition = 0; boardPosition < 9; boardPosition += 3)
            {
                if (WinOrNot(boardPosition))
                    return board[boardPosition];
            }
            return '-';


            //if (board[0] != '-' && board[0] == board[1]
            //                && board[1] == board[2])
            //    return board[0];
            //if (board[3] != '-' && board[3] == board[4]
            //                    && board[4] == board[5])
            //    return board[3];
            //if (board[6] != '-' && board[6] == board[7]
            //                    && board[7] == board[8])
            //    return board[6];
            //return '-';



        }

        private bool WinOrNot(int boardPosition)
        {
            return board[boardPosition] != '-' && board[boardPosition] == board[boardPosition + 1] && board[boardPosition] == board[boardPosition + 2];
        }
    }
}