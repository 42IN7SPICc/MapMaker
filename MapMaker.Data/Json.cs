using System.Collections.Generic;
using MapMaker.Data.Models;

namespace MapMaker.Data
{
    public class Json
    {
        public List<JsonTile> tiles { get; set; } = new();

        public Json()
        {
        }

        public Json(Builder builder)
        {
            foreach (var tile in builder.Map)
            {
                tiles.Add(new JsonTile
                {
                    type = tile.Type.ToString().ToLower(),
                    x = tile.X,
                    y = tile.Y
                });
            }
        }
        
        public class JsonTile
        {
            public string type { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }
    }
}