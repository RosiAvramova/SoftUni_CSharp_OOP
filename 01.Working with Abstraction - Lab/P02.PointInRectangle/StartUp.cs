using System;
using System.Linq;

namespace P02.PointInRectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] cordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int topLeftX = cordinates[0];
            int topLeftY = cordinates[1];
            int rightBottomX = cordinates[2];
            int rightBottomY = cordinates[3];


            Point firstPoint = new Point();
            firstPoint.X = topLeftX;
            firstPoint.Y = topLeftY;

            Point secondPoint = new Point();
            secondPoint.X = rightBottomX;
            secondPoint.Y = rightBottomY;

            Rectangle rectangle = new Rectangle();

            rectangle.TopLeft = firstPoint;
            rectangle.BottomRight = secondPoint;

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int[] points = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int x = points[0];
                int y = points[1];

                Point currPoint = new Point();
                currPoint.X = x;
                currPoint.Y = y;

                bool isInRectangle = rectangle.Contains(currPoint);
                Console.WriteLine(isInRectangle);
            }
        }
    }
}
