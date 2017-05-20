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
        public MainWindow()
        {
            Rectangles = new List<SnakeRectangle>();
            InitializeComponent();
            AddRectangles();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rectangles.Where(x=>x.Row==0&&x.Column<=3).ToList().ForEach(x=>x.Rectangle.Fill=Brushes.Black);
        }

        private void AddRectangles()
        {
            for (int i = 0; i < 100; i++)
            {
                var column = (int)Math.Floor(i / 10d);
                var row = i - 10 * column;
                var rectangle = new SnakeRectangle(new Rectangle(),column,row);
                Rectangles.Add(rectangle);
                Grid.SetColumn(rectangle.Rectangle, column);
                Grid.SetRow(rectangle.Rectangle, row);
                grid.Children.Add(rectangle.Rectangle);
            }

        }

        private void MoveSnake(Directions direction)
        {
            var filled = GetFilledRectangles();
            switch (direction)
            {
                    case Directions.Down:
                        filled[0].Rectangle.Fill = Brushes.Transparent;
                        
                    break;
            }
        }

        private SnakeRectangle[] GetFilledRectangles()
        {
            return Rectangles.Where(x => Equals(x.Rectangle.Fill, Brushes.Black)).ToArray();
        }
    }

    public enum Directions
    {
        Up,
        Down,
        Right,
        Left
    }

    public class SnakeRectangle
    {
        public Rectangle Rectangle;
        public int Row;
        public int Column;

        public SnakeRectangle()
        {
            
        }

        public SnakeRectangle(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public SnakeRectangle(Rectangle rectangle, int column, int row)
        {
            Rectangle = rectangle;
            Row = row;
            Column = column;
        }
    }
}
