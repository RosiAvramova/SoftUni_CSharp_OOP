using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ClassBoxDataValidation
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                this.ValidateParameters(value, nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {

                this.ValidateParameters(value, nameof(this.Width));
                this.width = value;
            }
        }


        public double Height
        {
            get => this.height;
            private set
            {
                ValidateParameters(value, nameof(this.Height));
                this.height = value;
            }
        }

        private void ValidateParameters(double value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero or negative.");
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2 * (length * width) + CalculateLateralSurfaceArea();
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * (length * height + width * height);
        }

        public double CalculateVolume()
        {
            return width * height * length;
        }
    }
}
