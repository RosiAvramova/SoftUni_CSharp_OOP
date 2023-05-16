using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ClassBox
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.lenght = lenght;
            this.width = width;
            this.height = height;
        }

        public double CalculateSurfaceArea()
        {
            return 2 * (lenght * width) + CalculateLateralSurfaceArea();
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * (lenght * height + width * height);
        }

        public double CalculateVolume()
        {
            return width * height * lenght;
        }
    }
}
