using System;
using System.Collections.Generic;
using System.Text;

namespace P02.PointInRectangle
{
    public class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Point BottomRight
        {
            get { return bottomRight; }
            set { bottomRight = value; }
        }

        public Point TopLeft
        {
            get { return topLeft; }
            set { topLeft = value; }
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal = this.TopLeft.X <= point.X && this.BottomRight.X >= point.X;

            bool isInVertical = this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;

            bool isInRectangle = isInHorizontal && isInVertical;

            return isInRectangle;
        }
    }
}
