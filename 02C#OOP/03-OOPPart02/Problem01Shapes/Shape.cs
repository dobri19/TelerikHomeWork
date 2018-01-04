using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01Shapes
{
    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (this.width < 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be negative!");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (this.height < 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative!");
                }
                this.height = value;
            }
        }

        public abstract double CalculateSurface();

        //public abstract string ToString();
    }
}
