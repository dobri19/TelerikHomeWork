using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01Shapes
{
    public class Square : Rectangle
    {
        public Square(double width)
            : base(width, width)
        {

        }

        public override double CalculateSurface()
        {
            double result = 0;

            result = this.Width * this.Width;

            return result;
        }

        public override string ToString()
        {
            return $"Square's side is {this.Width}, square's surface is {this.CalculateSurface()}!";
        }
    }
}
