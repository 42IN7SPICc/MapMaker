using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MapMaker.Data;
using MapMaker.Data.Extensions;
using MapMaker.Data.Models;
using Microsoft.Win32;

namespace MapMaker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Builder _builder = new();

        public MainWindow()
        {
            InitializeComponent();

            LoadMap();
        }

        private void LoadMap()
        {
            Stack.Children.Clear();

            for (var y = 0; y < Builder.Size; y++)
            {
                var innerTiles = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                
                for (var x = 0; x < Builder.Size; x++)
                {
                    var tile = _builder.Map.FirstOrDefault(t => t.X == x && t.Y == y);
                    if (tile != null)
                        innerTiles.Children.Add(GetRenderedTile(tile));
                }
                
                Stack.Children.Add(innerTiles);
            }
        }

        private Button GetRenderedTile(Tile tile)
        {
            var button = new Button()
            {
                Background = tile.GetBrush(),
                Content = tile.Type.ToString(),
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Width = 45,
                Height = 40,
                FontSize = 10
            };

            button.Click += (sender, args) =>
            {
                try
                {
                    tile.Type = (TileType) Enum.Parse(typeof(TileType), SelectedType.Text);
                }
                catch (Exception)
                {
                    // ignore
                }
                LoadMap();
            };

            return button;
        }

        private void Export_OnClick(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON file (*.json)|*.json"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _builder.Export(saveFileDialog.FileName);
            }
        }

        private void Import_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON file (*.json)|*.json"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _builder.Import(openFileDialog.FileName);
                LoadMap();
            }
        }
    }
}