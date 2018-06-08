using System;

namespace DAA_LPS
{
    class Program
    {
        
        static int LPS(string str)
        {
            int n = str.Length;
            int i, j, len;

            int[,] matrix = new int[n, n];

            for (i = 0; i < n; i++)
                matrix[i, i] = 1;


            for (len = 2; len <= n; len++)
            {
                for (i = 0; i < n - len + 1; i++)
                {
                    j = i + len - 1;

                    if (str[i].ToString().Equals(str[j].ToString(), StringComparison.OrdinalIgnoreCase) && len == 2)
                        matrix[i, j] = 2;
                    else if (str[i].ToString().Equals(str[j].ToString(), StringComparison.OrdinalIgnoreCase))
                        matrix[i, j] = matrix[i + 1, j - 1] + 2;
                    else
                        matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i + 1, j]);
                }
            }

            return matrix[0, n - 1];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter String Value : ");
            string str = Console.ReadLine();
            Console.WriteLine("The length of the LPS is " + LPS(str));
            Console.ReadKey();
        }
    }
}