using System;

class Program
{
    static void Main(string[] args)
    {
        int rows = 5; 

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(i); 
            }
            Console.WriteLine(); 
        }

        int row = 5; 

        for (int i = 1; i <= row; i++)
        {
            for (int j = i; j >= 1; j--)
            {
                Console.Write(j); 
            }
            Console.WriteLine();
        }

        int baris = 5; 

        for (int i = 1; i <= baris; i++)
        {
           
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }

            for (int k = i - 1; k >= 1 && i > 1; k--)
            {
                Console.Write(k);
            }

            Console.WriteLine(); 
        }

        int size = 5;
        int[,] matrix = new int[size, size];

        int num = 1;
        for (int i = 0; i < size; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[j, i] = num++;
                }
            }
            else
            {
                for (int j = size - 1; j >= 0; j--)
                {
                    matrix[j, i] = num++;
                }
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

}



