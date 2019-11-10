using System.Text;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToe
{
    public class GameTest
    {
        [Test]
        public void testOnlyAvailableMove()
        {
            var game = new Game("XOXOX-OXO");
            Assert.AreEqual(5, game.Move('X'));

            game = new Game("XOXOXOOX-");
            Assert.AreEqual(8, game.Move('O'));
        }

        [Test]
        public void testStartingDefaultMove()
        {
            Game game = new Game("---------");
            Assert.AreEqual(0, game.Move('X'));
        }

        [Test]
        public void testNoAvailableMove()
        {
            Game game = new Game("XXXXXXXXX");
            Assert.AreEqual(-1, game.Move('X'));
        }

        [Test]
        public void testFindWinningRowMove()
        {
            Game game = new Game("OO-XX-OOX");
            Assert.AreEqual(5, game.Move('X'));
        }

        [Test]
        public void testWinByRowConditions()
        {
            GameWinnerShouldBe("---XXX---", 'X');
            GameWinnerShouldBe("------OOO", 'O');
            GameWinnerShouldBe("YYY------", 'Y');

        }


        [Test]
        public void TestWinByNextMoveRowConditions()
        {
            var board = new StringBuilder("-XX------");
            var nextMoveSimulation = new NextMoveSimulation(board,0,'X');
            var winner = nextMoveSimulation.GetWinner();
            Assert.AreEqual('X', winner);
        }

        private void GameWinnerShouldBe(string boardString, char expectWinner)
        {
            var game = new Game(boardString);
            var actual = game.GetWinner();
            Assert.AreEqual(expectWinner,actual);
        }
    }
}