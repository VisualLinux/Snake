using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<SnakeRectangle> Rectangles;
        private Snake Snake;
        public MainWindow()
        {
            Rectangles = new List<SnakeRectangle>();
            InitializeComponent();
            AddRectangles();
            Rectangles.Where(x => x.Row == 0 && x.Column <= 3).ToList().ForEach(x => x.Rectangle.Fill = Brushes.Black);
            Snake = new Snake(4, GetFilledRectangles().ToList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rectangles.ForEach(x=>x.Rectangle.Fill=Brushes.Transparent);
            Snake.Rectangles.ForEach(x => GetRectangle(x).Rectangle.Fill = Brushes.Black);
            MoveSnake(Directions.Down);
        }

        private void AddRectangles()
        {
            for (int i = 0; i < 100; i++)
            {
                var row = (int)Math.Floor(i / 10d);
                var column = i - 10 * row;
                var rectangle = new SnakeRectangle(new Rectangle(), column, row);
                Rectangles.Add(rectangle);
                Grid.SetColumn(rectangle.Rectangle, column);
                Grid.SetRow(rectangle.Rectangle, row);
                grid.Children.Add(rectangle.Rectangle);
            }

        }

        private void MoveSnake(Directions direction)
        {
            Snake.Rectangles.RemoveAt(0);
            var nextRectangle = Snake.Rectangles.Last().GetNextRectangle(direction, grid.ColumnDefinitions.Count - 1,
                grid.RowDefinitions.Count - 1);
            Snake.Rectangles.Add(Rectangles.Where(x => x.SamePosition(nextRectangle)).ToList()[0]);
        }

        private SnakeRectangle[] GetFilledRectangles()
        {
            return Rectangles.Where(x => Equals(x.Rectangle.Fill, Brushes.Black)).ToArray();
        }

        private SnakeRectangle GetRectangle(SnakeRectangle rectangle)
        {
            return Rectangles.Where(x => x == rectangle).ToList()[0];
        }
    }
}