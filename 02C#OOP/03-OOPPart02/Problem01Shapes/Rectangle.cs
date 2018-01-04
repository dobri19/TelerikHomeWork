using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {

        }

        public override double CalculateSurface()
        {
            double result = 0;

            result = this.Height * this.Width;

            return result;
        }

        public override string ToString()
        {
            return $"Rectangle's side is {this.Width}, rectangle's height is {this.Height}, rectangle's surface is {this.CalculateSurface()}!";
        }
    }
}
