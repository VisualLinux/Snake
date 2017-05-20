using System;
using System.Windows.Shapes;

namespace Snake
{
    public class SnakeRectangle
    {
        public Rectangle Rectangle;
        public int Row;
        public int Column;

        public SnakeRectangle(Rectangle rectangle, int column, int row)
        {
            Rectangle = rectangle;
            Row = row;
            Column = column;
        }

        public SnakeRectangle GetNextRectangle(Directions direction, int maxcolumn, int maxrow)
        {
            var nextRow = Row;
            var nextColumn = Column;
            switch (direction)
            {
                case Directions.Up:
                    nextRow = MathHelper.BoundedAdd(Row, -1, maxrow, 0);
                    break;
                case Directions.Down:
                    nextRow = MathHelper.BoundedAdd(Row, 1, maxrow, 0);
                    break;
                case Directions.Right:
                    nextColumn = MathHelper.BoundedAdd(Column, 1, maxcolumn, 0);
                    break;
                case Directions.Left:
                    nextColumn = MathHelper.BoundedAdd(Column, -1, maxcolumn, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            return new SnakeRectangle(Rectangle, nextColumn, nextRow);
        }

        public bool SamePosition(SnakeRectangle rectangle)
        {
            return rectangle.Row == Row && rectangle.Column == Column;
        }
    }
}
