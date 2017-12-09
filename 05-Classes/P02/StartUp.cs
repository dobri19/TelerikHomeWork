using System;

namespace P02
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Point3D point01 = new Point3D(5, 6, 8);
            Console.WriteLine(point01.ToString());

            Point3D point02 = Point3D.Center;
            Console.WriteLine(point02.ToString());

            Console.WriteLine("Distance from {0} to {1} is {2}", point01.ToString(), point02.ToString(), Distance.CalculateDistance(point01, point02));

            Path path = new Path();
            path.Add(new Point3D(7, 7, 7));
            path.Add(new Point3D(2, 7, 8));
            path.Add(new Point3D(3, 3, 3));
            Console.WriteLine("Points in path", path.CountPoints);
            path.Remove(new Point3D(7, 7, 7));
            Console.WriteLine(path.CountPoints);

            // Loads points from file
            path = PathStorage.Load("../../input.txt");
            Console.WriteLine("\nPoints in path (total: {0})\n{1}", path.CountPoints, path);

            // Saves points in file
            PathStorage.Save(path, "../../output.txt");
            //Console.WriteLine("\nPoints in path (total: {0})\n{1}", path.CountPoints, path);


            //Point3D p02 = new Point3D(1, 9, 3);
            //Point3D p03 = new Point3D(7, 5, 2);

            //var path = new Path();
            //path.Add(p01);
            //path.Add(p02);
            //path.Add(p03);
            //Console.WriteLine(path.ToString());
            //path.Remove(p03);
            //Console.WriteLine(path.ToString());

            //var pero = new Person("Goran");
            //Console.WriteLine(pero.Name);

            //Console.WriteLine(Point3D.Center);

            //Singleton sng = new Singleton();
            //Singleton sng = Singleton.Instance;
            //Singleton sng1 = Singleton.Instance;
            //if (sng.Equals(sng1))
            //{
            //    Console.WriteLine("ok");
            //}
            //if (sng == sng1)
            //{
            //    Console.WriteLine("nt");
            //}
        }
    }
}
