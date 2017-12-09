using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04
{
    public class Matrix<T>
    {
        private T[,] myMatrix;
        private int rows;
        private int cols;

        public T[,] MyMatrix { get => myMatrix; set => myMatrix = value; }
        public int Rows { get => rows; set => rows = value; }
        public int Cols { get => cols; set => cols = value; }

        public Matrix()
        {
        }

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.MyMatrix = new T[rows, cols];
        }

        public T this[int row, int col]
        {
            get
            {
                return this.MyMatrix[row, col];
            }
            set
            {
                this.MyMatrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrice1, Matrix<T> matrice2)
        {
            if (matrice1.Rows != matrice2.Rows || matrice1.Cols != matrice2.Cols)
            {
                throw new ArgumentOutOfRangeException("The matrices are different!");
            }

            Matrix<T> matrixSum = new Matrix<T>(matrice1.Rows, matrice1.Cols);

            for (int i = 0; i < matrice1.Rows; i++)
            {
                for (int j = 0; j < matrice1.Cols; j++)
                {
                    //With dynamic
                    //matrixSum[i, j] = (dynamic)mat1[i, j] + mat2[i, j];

                    //With cast and IConvertible
                    //matrixSum[i, j] = (T)(object)(Convert.ToDouble(matrice1[i, j]) + Convert.ToDouble(matrice2[i, j]));
                    matrixSum[i, j] = (T)(object)(Convert.ToDouble(matrice1[i, j]) + Convert.ToDouble(matrice2[i, j]));
                }
            }
            return matrixSum;
        }

        public static Matrix<T> operator -(Matrix<T> matrice1, Matrix<T> matrice2)
        {
            if (matrice1.Rows != matrice2.Rows || matrice1.Cols != matrice2.Cols)
            {
                throw new ArgumentOutOfRangeException("The matrices are different!");
            }

            Matrix<T> matrixSub = new Matrix<T>(matrice1.Rows, matrice1.Cols);

            for (int i = 0; i < matrice1.Rows; i++)
            {
                for (int j = 0; j < matrice1.Cols; j++)
                {
                    //With dynamic
                    //matrixSum[i, j] = (dynamic)mat1[i, j] + mat2[i, j];

                    //With cast and IConvertible
                    //matrixSum[i, j] = (T)(object)(Convert.ToDouble(matrice1[i, j]) + Convert.ToDouble(matrice2[i, j]));
                    matrixSub[i, j] = (T)(object)(Convert.ToInt32(matrice1[i, j]) - Convert.ToInt32(matrice2[i, j]));
                }
            }
            return matrixSub;
        }

        public static Matrix<T> operator *(Matrix<T> mat1, Matrix<T> mat2)
        {

            if (mat1.Rows != mat2.Cols || mat1.Cols != mat2.Rows)
            {
                throw new ArgumentOutOfRangeException("The matrices cannot be multiplied!");
            }

            Matrix<T> matrixResult = new Matrix<T>(mat1.Rows, mat2.Cols);

            for (int row = 0; row < mat1.Rows; row++)
            {
                for (int col = 0; col < mat2.Cols; col++)
                {
                    for (int k = 0; k < mat1.Cols; k++)
                    {
                        matrixResult[row, col] += (dynamic)mat1[row, k] * mat2[k, col];
                    }
                }
            }
            return matrixResult;
        }

        //public static bool operator true(Matrix<T> mat1)
        //{
        //    for (int row = 0; row < mat1.Rows; row++)
        //    {
        //        for (int col = 0; col < mat1.Cols; col++)
        //        {
        //            if ((dynamic)mat1[row, col] == 0)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public static bool operator false(Matrix<T> mat1)
        //{
        //    for (int row = 0; row < mat1.Rows; row++)
        //    {
        //        for (int col = 0; col < mat1.Cols; col++)
        //        {
        //            if ((dynamic)mat1[row, col] == 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        public static bool operator true(Matrix<T> matrix)
        {
            return BooleanOperator(matrix, true);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return BooleanOperator(matrix, false);
        }


        private static bool BooleanOperator(Matrix<T> matrix, bool op)
        {
            foreach (T element in matrix.MyMatrix)
                if (!element.Equals(default(T)))
                    return op;

            return !op;
        }

        public override string ToString()
        {
            string str = String.Empty;
            string[] str1 = new string[this.Cols];
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    str += (this.MyMatrix[i, j] + (j != this.Cols - 1 ? "," : ""));
                }
                if (i!=this.Rows-1)
                {
                    str += "\n";
                }
            }
            return str;
        }
    }
}
