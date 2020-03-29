using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_Project_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            int sum_of_squares = 0;
            for (double i = 0; i <= 100; i++)
                numbers.Add(Math.Pow(i, 2));
            sum_of_squares = (int) numbers.Sum();
            numbers.Clear();

            for (double i = 0; i <= 100; i++)
                numbers.Add(i);

            int square_of_sum = (int) Math.Pow(numbers.Sum(), 2);

            Console.WriteLine($"Sum of squares: {sum_of_squares}\n" + 
                              $"Square of sum: {square_of_sum}\n" +
                              $"Difference: {square_of_sum - sum_of_squares}");
            Console.ReadKey();
        }
    }
}
