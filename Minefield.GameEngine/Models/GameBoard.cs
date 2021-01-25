using System;

namespace Minefield.GameEngine.Models
{
    public class GameBoard
    {
        public int Width { get; }
        public int Height { get; }
        public Tile[,] Tiles { get; private set; }
        public Player Player { get; set; }


        private const int AsciiCodeForCharA = 65;

        public GameBoard(int width, int height, int playerLives)
        {
            Width = width;
            Height = height;
            InitializeTiles();
            Player = CreatePlayer(playerLives);
        }

        /// <summary>
        /// Only mine 10% of the total tiles
        /// </summary>
        private void InitializeTiles()
        {
            Tiles = new Tile[Width, Height];

            for (var x = 0; x < Width; x++)
            {
                var labelAscii = AsciiCodeForCharA + x;
                var labelX = (char)labelAscii;

                for (var y = 0; y < Height; y++)
                {
                    var isMined = new Random().Next(1, 10) > 5 ? true : false;
                    Tiles[x, y] = new Tile(x, y, labelX.ToString(), (y + 1).ToString(), isMined);

                }
            }

        }

        private Player CreatePlayer(int playerLives)
        {
            Player player = null;

            for (int x = 0; x < Width; x++)
            {
                if (!Tiles[x, 0].IsMined)
                {
                    player = new Player(playerLives, Tiles[x, 0].Id, Tiles[x, 0].XPosition, Tiles[x, 0].YPosition, Tiles[x, 0].XPositionLabel + Tiles[x, 0].YPositionLabel);
                    break;
                }
            }

            return player;
        }
    }
}
