using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            var numbers = new List<int> { };
            for (int i = 1; i < 1000; i++) {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
