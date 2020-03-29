using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 1;
            var numbers = new List<int>{0};
            while (numbers.Max() < 4000000)
            {
                int temp = a;
                a = b;
                b = temp + b;
                numbers.Add(a);
                
            }
            numbers.RemoveAll(x => x > 4000000 || x % 2 != 0);

            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.ReadKey();
        }
    }
}
