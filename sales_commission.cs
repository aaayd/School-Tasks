using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Commission
{


    class Employee
    {
        public int Sales { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public double Commission { get; set; }

        public Employee(int sales, string name, int id)
        {
            Sales = sales;
            Name = name;
            ID = id;
            Commission = GetCommission();

        }

        private double GetCommission() => Commission = Sales * 500;
        
    }

    class Program
    {
        static int IntValidation(string inp)
        {
            int temp;
            while (true)
            {
                Console.Write(inp);
                if (int.TryParse(Console.ReadLine(), out temp))
                    break;

                Console.Clear();
                Console.WriteLine("[x] Ensure your input is a number!");
            }

            return temp;
        }
        static void Main(string[] args)
        {
            int employee_count;
            int _sales;
            int _id;

            employee_count = IntValidation("Input Employee counter : ");
            Employee[] employeeArray = new Employee[employee_count];

            for (int i = 0; i < employee_count; i++)
            {
                Console.Write($"Employee {i + 1} Name : ");
                var _name = Console.ReadLine();

                _sales = IntValidation($"Employee {i + 1} Sales : ");
                _id = IntValidation($"Employee {i + 1} ID : ");

                employeeArray[i] = new Employee(_sales, _name, _id);
                Console.Clear();
            }

            Array.Sort(employeeArray, (x, y) => x.Sales.CompareTo(y.Sales));
            Array.Reverse(employeeArray);
            // Sort Employee Array by Sales Property
            // Reverse array to order by descension (most sales -> least sales) 


            double bonus = employeeArray[0].Commission *.15;
            employeeArray[0].Commission += bonus;
            // Give most sales a 15% bonus

            Console.WriteLine($"{employeeArray[0].Name} [ID - {employeeArray[0].ID}] earned a bonus 15% (£{bonus:N2}) for having the most sales!\n");
            // Output top sale Employee + Output bonus earned

            foreach (Employee employee in employeeArray)
            {
                Console.WriteLine(
                    $"Employee" +
                    $"    Name - {employee.Name}" +
                    $"    ID - {employee.ID}" +
                    $"    Sales - {employee.Sales}" +
                    $"    Commission - £{employee.Commission:N2}"
                );
            }
            // Output all employee information (Name; ID; Sales; Commission)

            Console.WriteLine("--------------------------");
            Console.WriteLine($"Total Properties Sold - {employeeArray.Sum(employee => employee.Sales)}");
            // Output all properties sold in the week

            Console.WriteLine($"Total Sales Commission - £{employeeArray.Sum(employee => employee.Commission):N2}" );
            // Output total sales commission for the week

            Console.ReadKey();
        }
    }
}
