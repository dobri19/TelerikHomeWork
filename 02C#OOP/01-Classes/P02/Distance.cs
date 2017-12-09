using System;

namespace P02
{
    public static class Distance
    {
        public static double CalculateDistance(Point3D pointOne, Point3D pointTwo)
        {
            double result;
            result = Math.Pow((pointTwo.X - pointOne.Y), 2) +
                     Math.Pow((pointTwo.Y - pointOne.Y), 2) +
                     Math.Pow((pointTwo.Z - pointOne.Z), 2);
            result = Math.Sqrt(result);
            return result;
        }
    }
}
