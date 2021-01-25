using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minefield.GameEngine;
using Minefield.GameEngine.Models;

namespace Minefield.UnitTests
{
    [TestClass]
    public class GameServiceTests
    {
        [TestMethod]
        public void Start_DefaultSettings_InitializeNewGame()
        {
            // arrange
            IGameService gameService = new GameService();

            // act
            gameService.Start(new GameBoardSettings());
            
            // assert
            Assert.IsNotNull(gameService);
            Assert.IsTrue(gameService.Initialized);
        }

        [TestMethod]
        public void Start_ValidGameBoardSettings_InitializeNewGame()
        {
            // arrange
            IGameService gameService = new GameService();
            int gameBoardWidth = 5, gameBoardHeight = 10;
            var gameBoardSettings = new GameBoardSettings { Width = gameBoardWidth, Height = gameBoardHeight };

            // act
            gameService.Start(gameBoardSettings);

            // assert
            Assert.IsNotNull(gameService);
            Assert.IsNotNull(gameService.GameBoard);
            Assert.IsTrue(gameService.GameBoard.Width == gameBoardWidth);
            Assert.IsTrue(gameService.GameBoard.Height == gameBoardHeight);
            Assert.IsTrue(gameService.Initialized);
        }

        [TestMethod]
        public void Start_ValidGameBoardSettings_GenerateBoardGame()
        {
            // arrange
            IGameService gameService = new GameService();
            int gameBoardWidth = 5, gameBoardHeight = 10;
            var gameBoardSettings = new GameBoardSettings { Width = gameBoardWidth, Height = gameBoardHeight };
            var xAxisPosition = "E";
            var yAxisPosition = "5";

            // act
            gameService.Start(gameBoardSettings);

            // assert
            Assert.IsNotNull(gameService);
            Assert.IsNotNull(gameService.GameBoard);
            Assert.IsTrue(gameService.GameBoard.Width == gameBoardWidth);
            Assert.IsTrue(gameService.GameBoard.Height == gameBoardHeight);
            Assert.IsTrue(gameService.GameBoard.Tiles[4,4].XPositionLabel == xAxisPosition);
            Assert.IsTrue(gameService.GameBoard.Tiles[4,4].YPositionLabel == yAxisPosition);
            Assert.IsTrue(gameService.Initialized);
        }

        [TestMethod]
        public void Start_InValidGameBoardSettings_DoNotInitializeNewGame()
        {
            // arrange
            IGameService gameService = new GameService();
            int gameBoardWidth = -5, gameBoardHeight = -10;
            var gameBoardSettings = new GameBoardSettings { Width = gameBoardWidth, Height = gameBoardHeight };

            // act
            gameService.Start(gameBoardSettings);

            // assert
            Assert.IsNotNull(gameService);
            Assert.IsNull(gameService.GameBoard);
            Assert.IsFalse(gameService.Initialized);
        }

        [TestMethod]
        public void End_WithExistingGame_ClearInitialization()
        {
            // arrange
            IGameService gameService = new GameService();

            // act
            gameService.Start(new GameBoardSettings());
            gameService.End();

            // assert
            Assert.IsNotNull(gameService);
            Assert.IsFalse(gameService.Initialized);
        }


    }
}
