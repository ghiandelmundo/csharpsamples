using NUnit.Framework;

namespace MarkAnthonyGroup
{
    public class SolutionOneTests
    {
        private KingChessGame? kingChessGame;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckmateTest()
        {
            kingChessGame = new KingChessGame(new string[] { "(2,2)", "(1,1)" });
            Assert.AreEqual(0, kingChessGame.NumberOfMoves);
        }

        [Test]
        public void KingWithSixMoves()
        {
            kingChessGame = new KingChessGame(new string[] { "(4,4)", "(6,6)" });
            Assert.AreEqual(6, kingChessGame.NumberOfMoves);
        }

        [Test]
        public void KingNotChecked()
        {
            kingChessGame = new KingChessGame(new string[] { "(1,3)", "(4,4)" });
            Assert.AreEqual(-1, kingChessGame.NumberOfMoves);
        }
    }
}