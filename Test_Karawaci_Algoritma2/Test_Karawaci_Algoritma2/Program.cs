using System;

class Program
{
    static void Main(string[] args)
    {
        int[] input1 = { 1, 2, 3, 4, 5 };
        int[] input2 = { 15, 25, 35 };
        int[] input3 = { 8, 8 };

        int output1 = CalculateSum(input1);
        int output2 = CalculateSum(input2);
        int output3 = CalculateSum(input3);

        Console.WriteLine($"Output 1: {output1}");
        Console.WriteLine($"Output 2: {output2}");
        Console.WriteLine($"Output 3: {output3}");
    }

    static int CalculateSum(int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            if (num % 10 == 5)
            {
                sum += 2;
            }
            else
            {
                sum += 1;
            }
        }
        return sum;
    }
}
