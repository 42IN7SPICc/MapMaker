using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Text.Json;
using System.Windows;
using MapMaker.Data.Extensions;

namespace MapMaker.Data.Models
{
    public class Builder
    {
        public List<Tile> Map = new();
        public const int Size = 25;

        public Builder()
        {
            for (var x = 0; x < Size; x++)
            for (var y = 0; y < Size; y++)
                Map.Add(new Tile(x, y));
        }

        public void Export(string fileName)
        {
            try
            {
                var json = new Json(this);
                var contents = JsonSerializer.Serialize(json, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                
                File.WriteAllText(fileName, contents);

                using Process fileopener = new Process();
                fileopener.StartInfo.FileName = "explorer";
                fileopener.StartInfo.Arguments = "\"" + fileName + "\"";
                fileopener.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not serialize");
            }
        }

        public void Import(string fileName)
        {
            try
            {
                var contents = File.ReadAllText(fileName);
                var json = JsonSerializer.Deserialize<Json>(contents);
                Map.Clear();

                foreach (var tile in json.tiles)
                {
                    Enum.TryParse(tile.type.FirstCharToUpper(), out TileType type);
                    Map.Add(new Tile(tile.x, tile.y, type));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not deserialize");
            }
        }
    }
}