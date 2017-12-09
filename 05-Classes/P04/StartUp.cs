using System;

namespace P04
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Matrix<double> mat01= new Matrix<double>(3, 3);
            Matrix<double> mat02 = new Matrix<double>(3, 3);

            mat01[0, 0] = 0;
            mat01[0, 1] = 1;
            mat01[0, 2] = 2;
            mat01[1, 0] = 3;
            mat01[1, 1] = 4;
            mat01[1, 2] = 5;
            mat01[2, 0] = 6;
            mat01[2, 1] = 7;
            mat01[2, 2] = 8;

            mat02[0, 0] = 10;
            mat02[0, 1] = 11;
            mat02[0, 2] = 12;
            mat02[1, 0] = 13;
            mat02[1, 1] = 14;
            mat02[1, 2] = 15;
            mat02[2, 0] = 16;
            mat02[2, 1] = 17;
            mat02[2, 2] = 18;

            Matrix<double> mat03 = new Matrix<double>();
            mat03 = mat01 + mat02;
            Console.WriteLine(mat03.ToString());

            Console.WriteLine();

            Matrix<double> mat04 = new Matrix<double>();
            mat04 = mat01 * mat02;
            Console.WriteLine(mat04.ToString());

            Console.WriteLine();

            if (mat03)
            {
                Console.WriteLine(true);
            }

            Matrix<double> mat05 = new Matrix<double>(5,5);
            if (mat05)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            Console.WriteLine("First matrix: {0}", mat01 ? "Non-empty!" : "Empty!");
            Console.WriteLine("New matrix: {0}\n", new Matrix<double>(1, 1) ? "Non-empty!" : "Empty!");
        }
    }
}
