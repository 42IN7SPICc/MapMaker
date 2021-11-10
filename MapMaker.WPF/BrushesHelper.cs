using System;
using System.Windows.Media;
using MapMaker.Data.Models;

namespace MapMaker.WPF
{
    public static class BrushesHelper
    {
        public static SolidColorBrush GetBrush(this Tile tile) =>
            tile.Type switch
            {
                TileType.Bushes => Brushes.DarkGreen,
                TileType.Grass => Brushes.LawnGreen,
                TileType.Street => Brushes.DarkSlateGray,
                TileType.Sand => Brushes.SandyBrown,
                TileType.Water => Brushes.Aqua,
                TileType.Bridge => Brushes.Purple,
                TileType.Rocks => Brushes.Teal,
                TileType.Start => Brushes.Gold,
                TileType.End => Brushes.DarkGoldenrod,
                _ => Brushes.Black
            };
    }
}