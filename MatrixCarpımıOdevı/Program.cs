using System;

namespace MatrixCarpımıOdevı
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
            static void Main()
            {
                int[,] A = {
                { 1, 2, 3 },
                { 4, 5, 6 }
                };

                int[,] B = {
                { 7, 8 },
                { 9, 10 },
                { 11, 12 }
                };

                int[,] C = MatrisCarp(A, B);

                Console.WriteLine("Matris Çarpımı Sonucu:");
                for (int i = 0; i < C.GetLength(0); i++)
                {
                    for (int j = 0; j < C.GetLength(1); j++)
                    {
                        Console.Write(C[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            static int[,] MatrisCarp(int[,] A, int[,] B)
            {
                int m = A.GetLength(0);
                int n = A.GetLength(1);
                int p = B.GetLength(1);

                int[,] C = new int[m, p];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < p; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            C[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }

                return C;
            }
        
    }
}
