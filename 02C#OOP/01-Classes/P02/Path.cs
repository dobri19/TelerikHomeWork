using System;
using System.Collections.Generic;

namespace P02
{
    public class Path
    {
        //private List<Point3D> points;
        public int CountPoints
        {
            get
            {
                return this.Points.Count;
            }
        }

        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public List<Point3D> Points { get; set; }

        public Point3D this[int index]
        {
            get
            {
                return this.Points[index];
            }
            set
            {
                this.Points[index] = value;
            }
        }

        public void Add(Point3D point)
        {
            this.Points.Add(point);

        }

        public void Remove(Point3D point)
        {
            this.Points.Remove(point);
        }

        public override string ToString()
        {
            return String.Join("\n", this.Points);
        }
    }
}
