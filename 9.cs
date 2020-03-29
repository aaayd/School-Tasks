using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_Project_9
{
    class Program
    {
        static void Main(string[] args)
        {
            const int target = 1000;

            for (int a = 0; a < target / 3; a++) {
                for (int b = a; b < target / 2; b++) {
                    int c = target - a - b;
                    bool triplet = a * a + b * b == c * c;

                    if (triplet) {
                        Console.WriteLine($"Triplet: {a}, {b}, {c}\n" +
                                          $"Sum: {a} + {b} + {c} = {a+b+c}\n" +
                                          $"Product: {a} × {b} × {c} = {a*b*c}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
