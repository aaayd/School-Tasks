using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{

    class Program
    {

        enum BoolAlias
        {
            // Using an enumerator as it is easily modifiable and readable 

            Y = 1,
            YES = 1,
            STAFF = 1,
            TRUE = 1,
            N = 0,
            NO = 0,
            FALSE = 0
        }

        private static bool StrToBool(string str)
        {
            return Convert.ToBoolean(
                Enum.Parse(typeof(BoolAlias), str.ToUpper())
            );
        }

        private static double GetFeeVal(double num)
        {
            if (300 >= num) {
                return 3.5; }

            if (300 < num && num <= 750) {
                return 3.0; }

            if (750 < num && num <= 1000) { 
                return  2.5; }

            if (1000 < num && num <= 2000) { 
                return 2.0; }

            return 1.5;

        }
        static void Main(string[] args)
        {
            double transaction;
            double currency;
            double discounted = 0.0;
            double transactionFee;
            bool isStaff;

            Dictionary<string, double> currencyDict = new Dictionary<string, double>()
            {
                { "USD", 1.40 },
                { "EUR", 1.14 },
                { "BRL", 4.77 },
                { "JPY", 151.05 },
                { "TRY", 5.68 }

            };
            

            Console.WriteLine("Currencies: \n    " + string.Join(",\n    ", currencyDict.Keys.ToList()));

            while (true) {
                Console.Write("\nInput Currency : ");
                if (currencyDict.TryGetValue(Console.ReadLine().ToUpper(), out currency))
                    break;

                Console.WriteLine("[x] Ensure you have typed a currency which exists!");
            }
            Console.Clear();

            while (true) {
                Console.Write("Transaction Amount (GBP) : £");
                if (double.TryParse(Console.ReadLine(), out transaction) && (transaction <= 2500 && transaction > 0))
                    break;
                    
                Console.WriteLine("[x] Ensure you have a NUMBER value between £1 - 2500!\n");
            }
            Console.Clear();

            while (true)
            {
                try
                {
                    Console.Write("Is customer staff (Yes / No) : ");
                    isStaff = StrToBool(Console.ReadLine());

                    break;

                } catch (ArgumentException) {
                    Console.WriteLine("[x] Ensure you have input [YES] or [NO]!\n");
                }

                
            }
            Console.Clear();

            transactionFee = (GetFeeVal(transaction) / 100) * transaction ;
            if (isStaff) 
                discounted = (transactionFee * 1.05) - transactionFee;

            Console.WriteLine($"Transaction Fee: £{transactionFee:N2}");
            Console.WriteLine($"Discount Amount: £{discounted:N2}");
            transactionFee -= discounted;

            Console.WriteLine($"Total Transaction Cost: £{transactionFee:N2}");

            Console.Write($"    £{transaction:N2} -> ");
            transaction -= transactionFee;

            Console.Write($"£{transaction:N2} ");
            Console.WriteLine("\n\nConverted Currency:");
            Console.WriteLine($"    {transaction:N2} (GBP) -> {transaction * currency:N2} ({currencyDict.FirstOrDefault(x => x.Value == currency).Key})");
            
            Console.ReadKey();
        }
    }
}
