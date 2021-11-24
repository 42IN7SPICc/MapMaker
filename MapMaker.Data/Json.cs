using System.Collections.Generic;
using MapMaker.Data.Models;

namespace MapMaker.Data
{
    public class Json
    {
        public string title { get; set; } = "level name";
        public string description { get; set; } = "level description";
        public int unlockThreshold { get; set; } = 0;
        public List<JsonTile> tiles { get; set; } = new();

        public Json()
        {
        }

        public Json(Builder builder)
        {
            title = builder.Title;
            description = builder.Description;
            unlockThreshold = builder.UnlockThreshold;
            
            foreach (var tile in builder.Map)
            {
                tiles.Add(new JsonTile
                {
                    type = (int) tile.Type,
                    x = tile.X,
                    y = tile.Y
                });
            }
        }
        
        public class JsonTile
        {
            public int type { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }
    }
}