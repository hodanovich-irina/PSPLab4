//using Accord.Math;

//public class MinorResolver
//{
//    private readonly double[,] _matrix;

//    public MinorResolver(double[,] matrix)
//    {
//        _matrix = matrix;
//    }

//    public double[,] Resolve() // include only start!
//    {
//        var size = _matrix.GetLength(0);
//        var minorMatrix = new double[size, size];

//        for (int i = 0; i < size; i++)
//        {
//            for (int j = 0; j < size; j++)
//            {
//                minorMatrix[i, j] = GetMinor(i, j);
//            }
//        }

//        return minorMatrix;
//    }

//    private double GetMinor(int row, int column)
//    {
//        var size = _matrix.GetLength(0);
//        var result = new double[size - 1, size - 1];

//        int m = 0;
//        int k = 0;

//        for (int i = 0; i < size; i++)
//        {
//            if (i == row)
//            {
//                continue;
//            }

//            k = 0;
//            for (int j = 0; j < size; j++)
//            {
//                if (j == column)
//                {
//                    continue;
//                }

//                result[m, k++] = _matrix[i, j];
//            }

//            m++;
//        }

//        return result.Determinant();
//    }
//}

//class Program 
//{
//    public static string Result() 
//    {
//        var resStr = "";
//        double[,] matrix = new double[,] { { 2, 3, 3, 1 },
//                                     { 3, 5, 3, 2 },
//                                     { 5, 7, 6, 2 },
//                                     { 4, 4, 3, 1 } };
//        double[] v = new double[] {1,2,3,4 };
//        var det = matrix.Determinant();
//        if (det == 0)
//        {
//            throw new ArgumentException("Определитель не может быть 0");
//        }

//        var resolver = new MinorResolver(matrix);
//        var minors = resolver.Resolve();

//        var result = minors.CreateAdditions();
//        result = result.Transpose();
//        var result1 = result.Dot(v);
//        var itog = result1.Divide(-3);
//        for (var i = 0; i < itog.Length; i++) 
//        {
//            Console.WriteLine(Math.Round(itog[i],2));
//            resStr += Math.Round(itog[i], 2) + " ";
//        }

//        return resStr;  
//        // Все, result - и есть обратная матрица 
//    }
    
//}