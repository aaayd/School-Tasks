using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_Project_3
{
    class Program
    {
        static int LargestPrimeFactor(long target)
        {
            List<int> factors_of_target = new List<int>();
            for (int i = 2; i <= target; i++) {
                if (target % i == 0) {
                    long temp = target / i;
                    factors_of_target.Add(i);
                    
                    target = temp;
                    i--;
                }
            }
            return factors_of_target.Aggregate((a, x) => a * x) == target ? 0 : factors_of_target.Max();
        }
        static void Main(string[] args)
        {
            const long target = 600851475143;
            Console.WriteLine($"Target: {target}");
            Console.WriteLine($"Largest Prime Factor: {LargestPrimeFactor(target)}");
            Console.ReadKey();
        }
    }
}

