using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static bool gameongoing = true;
        static bool GameOver = false;
        static string winningPlayer = "0";
        static int[] usedFields = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static string[,] matrix =
        { 
            {"1", "2", "3"}, 
            {"4", "5", "6"},
            {"7", "8", "9"}
        };

        static void Main(string[] args)
        {
            while (gameongoing == true)
            {
                CreateTicTacToe();
                while (GameOver == false)
                {
                    PlayerOne();
                    CheckWinOne();
                    if (GameOver == true)
                    {
                        break;
                    }
                    PlayerTwo();
                    CheckWinTwo();
                    if (GameOver == true)
                    {
                        break;
                    }
                }
                WinnerAnnouncement();
                Restart();
            }
            Console.ReadLine();
        }

        public static void CreateTicTacToe()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ",matrix[0,0], matrix[0,1], matrix[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ",matrix[1,0], matrix[1,1], matrix[1,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ",matrix[2,0], matrix[2,1], matrix[2,2]);
            Console.WriteLine("     |     |     ");
        }
        public static void PlayerOne()
        {
            bool noRightInput = true;
            while (noRightInput)
            {
                bool numberUsed = false;
                int inputNumber;
                Console.Write("Player 1: Choose your field:");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out inputNumber);
                if (success)
                {
                    if (inputNumber > 0 & inputNumber < 10)
                    {
                        foreach (int k in usedFields)
                        {
                            if (inputNumber == usedFields[k])
                            {
                                numberUsed = true;
                                Console.WriteLine("Number has been selected before.");
                            }
                        }
                        if (numberUsed == false)
                        {
                            switch (inputNumber)
                            {
                                case 1:
                                    matrix[0, 0] = "X";
                                    usedFields[0] = 1;
                                    break;
                                case 2:
                                    matrix[0, 1] = "X";
                                    usedFields[1] = 2;
                                    break;
                                case 3:
                                    matrix[0, 2] = "X";
                                    usedFields[2] = 3;
                                    break;
                                case 4:
                                    matrix[1, 0] = "X";
                                    usedFields[3] = 4;
                                    break;
                                case 5:
                                    matrix[1, 1] = "X";
                                    usedFields[4] = 5;
                                    break;
                                case 6:
                                    matrix[1, 2] = "X";
                                    usedFields[5] = 6;
                                    break;
                                case 7:
                                    matrix[2, 0] = "X";
                                    usedFields[6] = 7;
                                    break;
                                case 8:
                                    matrix[2, 1] = "X";
                                    usedFields[7] = 8;
                                    break;
                                case 9:
                                    matrix[2, 2] = "X";
                                    usedFields[8] = 9;
                                    break;
                            }
                            noRightInput = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Number is out of bounds. Please enter a legitimate field.");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format entered. Please enter a legitimate field.");
                }
            }
        }
        public static void PlayerTwo()
        {
            bool noRightInput = true;
            while (noRightInput)
            {
                bool numberUsed = false;
                int inputNumber;
                Console.Write("Player 2: Choose your field:");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out inputNumber);
                if (success)
                {
                    if (inputNumber > 0 & inputNumber < 10)
                    {
                        foreach (int k in usedFields)
                        {
                            if (inputNumber == k)
                            {
                                numberUsed = true;
                                Console.WriteLine("Number has been selected before.");
                            }
                        }
                        if (numberUsed == false)
                        {
                            switch (inputNumber)
                            {
                                case 1:
                                    matrix[0, 0] = "O";
                                    usedFields[0] = 1;
                                    break;
                                case 2:
                                    matrix[0, 1] = "O";
                                    usedFields[1] = 2;
                                    break;
                                case 3:
                                    matrix[0, 2] = "O";
                                    usedFields[2] = 3;
                                    break;
                                case 4:
                                    matrix[1, 0] = "O";
                                    usedFields[3] = 4;
                                    break;
                                case 5:
                                    matrix[1, 1] = "O";
                                    usedFields[4] = 5;
                                    break;
                                case 6:
                                    matrix[1, 2] = "O";
                                    usedFields[5] = 6;
                                    break;
                                case 7:
                                    matrix[2, 0] = "O";
                                    usedFields[6] = 7;
                                    break;
                                case 8:
                                    matrix[2, 1] = "O";
                                    usedFields[7] = 8;
                                    break;
                                case 9:
                                    matrix[2, 2] = "O";
                                    usedFields[8] = 9;
                                    break;
                            }
                            noRightInput = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Number is out of bounds. Please enter a legitimate field.");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format entered. Please enter a legitimate field.");
                }
            }
        }
        public static void CheckWinOne()
        {
            Console.Clear();
            CreateTicTacToe();
            if ((matrix[0,0] == "X" & matrix[0,1] == "X" & matrix[0,2] == "X") ||
                (matrix[1,0] == "X" & matrix[1,1] == "X" & matrix[1,2] == "X") ||
                (matrix[2,0] == "X" & matrix[2,1] == "X" & matrix[2,2] == "X") ||
                (matrix[0,0] == "X" & matrix[1,0] == "X" & matrix[2,0] == "X") ||
                (matrix[0,1] == "X" & matrix[1,1] == "X" & matrix[2,1] == "X") ||
                (matrix[0,2] == "X" & matrix[1,2] == "X" & matrix[2,2] == "X") ||
                (matrix[0,0] == "X" & matrix[1,1] == "X" & matrix[2,2] == "X") ||
                (matrix[0,2] == "X" & matrix[1,1] == "X" & matrix[2,0] == "X"))
            {
                GameOver = true;
                winningPlayer = "1";
            }
            if (
            matrix[0, 0] != "1" & matrix[0, 1] != "2" & matrix[0, 2] != "3" &
            matrix[1, 0] != "4" & matrix[1, 1] != "5" & matrix[1, 2] != "6" &
            matrix[2, 0] != "7" & matrix[2, 1] != "8" & matrix[2, 2] != "9")
            {
                GameOver = true;
            }
        }
        public static void CheckWinTwo()
        {
            Console.Clear();
            CreateTicTacToe();
            if ((matrix[0, 0] == "O" & matrix[0, 1] == "O" & matrix[0, 2] == "O") ||
                (matrix[1, 0] == "O" & matrix[1, 1] == "O" & matrix[1, 2] == "O") ||
                (matrix[2, 0] == "O" & matrix[2, 1] == "O" & matrix[2, 2] == "O") ||
                (matrix[0, 0] == "O" & matrix[1, 0] == "O" & matrix[2, 0] == "O") ||
                (matrix[0, 1] == "O" & matrix[1, 1] == "O" & matrix[2, 1] == "O") ||
                (matrix[0, 2] == "O" & matrix[1, 2] == "O" & matrix[2, 2] == "O") ||
                (matrix[0, 0] == "O" & matrix[1, 1] == "O" & matrix[2, 2] == "O") ||
                (matrix[0, 2] == "O" & matrix[1, 1] == "O" & matrix[2, 0] == "O"))
            {
                GameOver = true;
                winningPlayer = "2";
            }
            if (
            matrix[0, 0] != "1" & matrix[0, 1] != "2" & matrix[0, 2] != "3" &
            matrix[1, 0] != "4" & matrix[1, 1] != "5" & matrix[1, 2] != "6" &
            matrix[2, 0] != "7" & matrix[2, 1] != "8" & matrix[2, 2] != "9")
            {
                GameOver = true;
            }
        }
        public static void WinnerAnnouncement()
        {
            if (winningPlayer != "0")
            {
            Console.WriteLine("Game Over! Player {0} is the winner!", winningPlayer);
            }
            else
            {
                Console.WriteLine("Cat's Game! There is no winner");
            }

        }
        public static void Restart()
        {
            Console.WriteLine("Would you like to restart the game? Y/N");
            string input = Console.ReadLine();
            string inputlower = input.ToLower();
            if (inputlower == "y")
            {
                for (int k = 0; k < 9; k++)
                {
                    usedFields[k] = 0;
                }
                matrix[0, 0] = "1";
                matrix[0, 1] = "2";
                matrix[0, 2] = "3";
                matrix[1, 0] = "4";
                matrix[1, 1] = "5";
                matrix[1, 2] = "6";
                matrix[2, 0] = "7";
                matrix[2, 1] = "8";
                matrix[2, 2] = "9";
                Console.Clear();
                winningPlayer = "0";
                GameOver = false;
            }
            else
            {
                Console.WriteLine("Shutting Down....");
                gameongoing = false;
            }
        }
    }
}