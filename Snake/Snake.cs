using System.Collections.Generic;

namespace Snake
{

    public class Snake
    {
        public int Length { get; set; }
        public List<SnakeRectangle> Rectangles { get; set; }

        public Snake(int length, List<SnakeRectangle> rectangles)
        {
            Length = length;
            Rectangles = rectangles;
        }

        //public Directions GetDirection()
        //{
            
        //}
    }
}
