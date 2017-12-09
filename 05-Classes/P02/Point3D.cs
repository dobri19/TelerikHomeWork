using System;
using System.Text;

namespace P02
{
    public struct Point3D
    {
        //public string Name { get; set; }

        private static readonly Point3D center = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D Center
        {
            get
            {
                return Point3D.center;
            }
        }

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        //public string Name { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Point(").Append("X=").Append(this.X).Append(",").Append("Y=").Append(this.Y).Append(",").Append("Z=").Append(this.Z).Append(")");
            return sb.ToString();
        }
    }
}
