using System;

namespace Minefield.GameEngine.Models
{
    public class GameBoard
    {
        public int Width { get; }
        public int Height { get; }
        public Tile[,] Tiles { get; private set; }

        private const int AsciiCodeForCharA = 65;

        public GameBoard(int width, int height)
        {
            Width = width;
            Height = height;
            InitializeTiles();       
        }

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
    }
}
