namespace MapMaker.Data.Models
{
    public class Tile
    {
        public TileType Type;
        public int X;
        public int Y;
        
        public Tile(int x, int y, TileType type = TileType.Bushes)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }

    public enum TileType
    {
        Bushes = 0,
        Grass = 1,
        Street = 2,
        Sand = 3,
        Water = 4,
        Bridge = 5,
        Rocks = 6,
        Start = 7,
        End = 8
    }
}