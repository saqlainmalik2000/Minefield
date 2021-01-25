using System;

namespace Minefield.GameEngine.Models
{
    public class Tile
    {
        public Tile(int xPosition, int yPosition, string xPositionLabel, string yPositionLabel, bool isMined)
        {
            Id = Guid.NewGuid().ToString();
            XPosition = xPosition;
            YPosition = yPosition;
            XPositionLabel = xPositionLabel;
            YPositionLabel = yPositionLabel;
            IsMined = isMined;
        }

        public int XPosition { get; }
        public int YPosition { get; }
        public string XPositionLabel { get; }
        public string YPositionLabel { get; }
        public bool IsMined { get; }
        public string Id { get; internal set; }
    }
}
