using System;
using System.Collections.Generic;

namespace Problem01Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape sh01 = new Triangle(3, 8);
            Shape sh02 = new Rectangle(2, 4);
            Shape sh03 = new Square(6);

            IEnumerable<Shape> shapes = new List<Shape>
            {
                sh01,
                sh02,
                sh03
            };

            foreach (var item in shapes)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
