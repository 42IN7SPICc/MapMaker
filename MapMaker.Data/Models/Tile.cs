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
        Bushes,
        Grass,
        Street,
        Sand,
        Water,
        Bridge,
        Rocks,
        Start,
        End
    }
}