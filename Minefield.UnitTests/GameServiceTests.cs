using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minefield.GameEngine;

namespace Minefield.UnitTests
{
    [TestClass]
    public class GameServiceTests
    {
        [TestMethod]
        public void Start_AnyStartingPoint_InitializeNewGame()
        {
            // arrange
            IGameService board = new GameService();

            // act
            board.Start();
            
            // assert
            Assert.IsNotNull(board);
            Assert.IsTrue(board.Initialized);
        }

        [TestMethod]
        public void End_WithExistingGame_ClearInitialization()
        {
            // arrange
            IGameService board = new GameService();

            // act
            board.Start();
            board.End();

            // assert
            Assert.IsNotNull(board);
            Assert.IsFalse(board.Initialized);
        }


    }
}
