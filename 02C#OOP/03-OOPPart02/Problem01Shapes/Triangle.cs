using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {

        }

        public override double CalculateSurface()
        {
            double result = 0;

            result = this.Height * this.Width / 2;

            return result;
        }

        public override string ToString()
        {
            return $"Triangle's side is {this.Width}, triangle's height is {this.Height}, triangle's surface is {this.CalculateSurface()}!";
        }
    }
}
