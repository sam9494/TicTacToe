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

        private void GameWinnerShouldBe(string boardString, char expectWinner)
        {
            var game = new Game(boardString);
            var board = game.GetBoard();
            var actual = board.Winner();
            Assert.AreEqual(expectWinner,actual);
        }
    }
}