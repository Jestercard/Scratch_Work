using System;
using System.Threading;

namespace Challenge_377___Reddit
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions f = new Functions();
            Modes m = new Modes();
            Console.WriteLine("----------Boxes into Container Calculator----------");
            Thread.Sleep(2000);
            int turn = m.CanYouTurn();

            Console.WriteLine("Input the X paramater for the Container: ");
            f.X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the Y paramater for the Container: ");
            f.Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the x paramater for the Box: ");
            f.x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the y paramater for the Box: ");
            f.y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Container size is {0}x{1}.", f.X, f.Y);
            Thread.Sleep(500);
            Console.WriteLine("Box size is {0}x{1}.", f.x, f.y);
            Thread.Sleep(500);
            Console.WriteLine("Is This True? Y/N");
            string input2 = Console.ReadLine();
            string lowerinput2 = input2.ToLower();
            if (lowerinput2 == "y")
            {
                if (turn == 0)
                {
                    Console.WriteLine("You can fit {0} Boxes in the container.", f.fit1(f.X, f.Y, f.x, f.y));
                }
                else
                {
                    int NoTurn = f.fit1(f.X, f.Y, f.x, f.y);
                    int Turn = f.fit2(f.X, f.Y, f.x, f.y);
                    if (NoTurn > Turn)
                    {
                        Console.WriteLine("It is best to not turn as you can fit {0} Boxes in the container.", f.fit1(f.X, f.Y, f.x, f.y));
                    }
                    else
                    {
                        Console.WriteLine("It is best to turn as you can fit {0} Boxes in the container.", f.fit2(f.X, f.Y, f.x, f.y));
                    }
                }
            }
            else if (lowerinput2 == "n")
            {
                Console.WriteLine("Restarting...");
            }
            else
            {
                Console.WriteLine("Shutting Down...");
            }
        }
    }
    class Functions
    {
        public int X, Y, x, y;

        private int deltaX, deltaY, Total, TotalTurn;

        public int fit1(int X, int Y, int x, int y)
        {
            deltaX = X / x;
            deltaY = Y / y;
            Total = deltaX * deltaY;
            return Total;
        }

        public int fit2(int X, int Y, int x, int y)
        {

            deltaX = X / y;
            deltaY = Y / x;
            TotalTurn = deltaX * deltaY;
            return TotalTurn;
        }

    }
    class Modes
    {
        public int CanYouTurn()
        {
            Console.WriteLine("Are you able to turn the boxes in the container? Y/N");
            string input1 = Console.ReadLine();
            string lowerinput1 = input1.ToLower();
            if (lowerinput1 == "y")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int Dimensions()
        {
            Console.WriteLine("How Many Dimensions is your container? 2/3/4");
            int Dims = Convert.ToInt32(Console.ReadLine());
            return Dims;
        }
    }
}