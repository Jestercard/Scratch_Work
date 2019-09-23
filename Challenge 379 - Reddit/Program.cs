using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_379
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tax tax = new Tax();
            bool Ongoing = true;
            do
            {
                tax.PrintChart();
                Console.Write("How much was your income? (Enter X to exit): ");
                string input = Console.ReadLine();
                input = input.ToLower();
                if (input != "x")
                {
                    bool success = double.TryParse(input, out double income);
                    if (success == true)
                    {
                        tax.TaxOwed(income);
                        Console.WriteLine("With an income of ${0}, you will pay ${1} in taxes.", income, tax.taxes);
                        Console.WriteLine("Press enter to try another value");
                    }
                    else
                    {
                        throw new Exception("Incorrect Value entered.");
                    }
                }
                else
                {
                    Ongoing = false;
                    continue;
                }
                Console.ReadLine();
                Console.Clear();
            } while (Ongoing == true);
            Console.WriteLine("Good Bye!");

            Console.ReadLine();
        }
    }
}
