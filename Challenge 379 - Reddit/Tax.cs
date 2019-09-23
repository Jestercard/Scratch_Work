using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_379
{
    public class Tax
    {
        private double BracketOneCap = 10000;
        private double BracketTwoCap = 30000;
        private double BracketThreeCap = 100000;

        private double BracketOneRate = 0.0;
        private double BracketTwoRate = 0.1;
        private double BracketThreeRate = 0.25;
        private double BracketFourRate = 0.4;

        public double taxes;

        public Tax() { }

        public void PrintChart()
        {
            Console.WriteLine("Hello There! Welcome to the tax program.");
            Console.WriteLine("Below is a breakdown of the tax brackets and the their rates.");
            Console.WriteLine("");
            Console.WriteLine("Bracket      Cap         Rate");
            Console.WriteLine("_____________________________");
            Console.WriteLine("1            10000        0%");
            Console.WriteLine("2            30000       10%");
            Console.WriteLine("3            100000      25%");
            Console.WriteLine("4            100000+     40%");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void TaxOwed(double income)
        {
            if (income >= BracketOneCap)
            {
                if (income >= BracketTwoCap)
                {
                    if (income >= BracketThreeCap)
                    {
                        double taxableIncome = income - BracketThreeCap;
                        taxes = (taxableIncome * BracketFourRate) + ((BracketThreeCap - BracketTwoCap) * BracketThreeRate) + ((BracketTwoCap - BracketOneCap) * BracketTwoRate) + (BracketOneCap * BracketOneRate);
                    }
                    else
                    {
                        double taxableIncome = income - BracketTwoCap;
                        taxes = (taxableIncome * BracketThreeRate) + ((BracketTwoCap - BracketOneCap) * BracketTwoRate) + (BracketOneCap * BracketOneRate);

                    }
                }
                else
                {
                    double taxableIncome = income - BracketOneCap;
                    taxes = (taxableIncome * BracketTwoRate) + (BracketOneCap * BracketOneRate);
                }
            }
            else
            {
                taxes = (income * BracketOneRate);
            }
        }
    }
}
