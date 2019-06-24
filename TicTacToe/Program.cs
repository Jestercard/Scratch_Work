using System;

namespace TicTacToe
{
    class Program
    {
        static bool gameOngoing = true;
        static bool gameOver = false;
        static int winningPlayer = 0;
        static string playerSign;
        static readonly int[] usedFields = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static readonly string[,] matrix =
        { 
            {"1", "2", "3"}, 
            {"4", "5", "6"},
            {"7", "8", "9"}
        };

        static void Main(string[] args)
        {
            while (gameOngoing == true)
            {
                CreateTicTacToe();
                while (gameOver == false)
                {
                    PlayerMove(1);
                    CheckWin(1);
                    if (gameOver == true)
                    {
                        break;
                    }
                    PlayerMove(2);
                    CheckWin(2);
                    if (gameOver == true)
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
            Console.Clear();
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
        public static void PlayerMove(int player)
        {
            bool noRightInput = true;
            if (player == 1)
            {
                playerSign = "X";
            }else if (player == 2)
            {
                playerSign = "O";
            }
            while (noRightInput)
            {
                bool numberUsed = false;
                Console.Write("Player {0}: Choose your field for {1}:", player, playerSign);
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int inputNumber);
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
                                break;
                            }
                        }
                        if (numberUsed == false)
                        {
                            switch (inputNumber)
                            {
                                case 1:
                                    matrix[0, 0] = playerSign;
                                    usedFields[0] = 1;
                                    break;
                                case 2:
                                    matrix[0, 1] = playerSign;
                                    usedFields[1] = 2;
                                    break;
                                case 3:
                                    matrix[0, 2] = playerSign;
                                    usedFields[2] = 3;
                                    break;
                                case 4:
                                    matrix[1, 0] = playerSign;
                                    usedFields[3] = 4;
                                    break;
                                case 5:
                                    matrix[1, 1] = playerSign;
                                    usedFields[4] = 5;
                                    break;
                                case 6:
                                    matrix[1, 2] = playerSign;
                                    usedFields[5] = 6;
                                    break;
                                case 7:
                                    matrix[2, 0] = playerSign;
                                    usedFields[6] = 7;
                                    break;
                                case 8:
                                    matrix[2, 1] = playerSign;
                                    usedFields[7] = 8;
                                    break;
                                case 9:
                                    matrix[2, 2] = playerSign;
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

        public static void CheckWin(int player)
        {
            CreateTicTacToe();
            if ((matrix[0,0] == playerSign & matrix[0,1] == playerSign & matrix[0,2] == playerSign) ||
                (matrix[1,0] == playerSign & matrix[1,1] == playerSign & matrix[1,2] == playerSign) ||
                (matrix[2,0] == playerSign & matrix[2,1] == playerSign & matrix[2,2] == playerSign) ||
                (matrix[0,0] == playerSign & matrix[1,0] == playerSign & matrix[2,0] == playerSign) ||
                (matrix[0,1] == playerSign & matrix[1,1] == playerSign & matrix[2,1] == playerSign) ||
                (matrix[0,2] == playerSign & matrix[1,2] == playerSign & matrix[2,2] == playerSign) ||
                (matrix[0,0] == playerSign & matrix[1,1] == playerSign & matrix[2,2] == playerSign) ||
                (matrix[0,2] == playerSign & matrix[1,1] == playerSign & matrix[2,0] == playerSign))
            {
                gameOver = true;
                winningPlayer = player;
            }
            if (
            matrix[0, 0] != "1" & matrix[0, 1] != "2" & matrix[0, 2] != "3" &
            matrix[1, 0] != "4" & matrix[1, 1] != "5" & matrix[1, 2] != "6" &
            matrix[2, 0] != "7" & matrix[2, 1] != "8" & matrix[2, 2] != "9")
            {
                gameOver = true;
            }
        }
        public static void WinnerAnnouncement()
        {
            if (winningPlayer != 0)
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
                winningPlayer = 0;
                gameOver = false;
            }
            else
            {
                Console.WriteLine("Shutting Down....");
                gameOngoing = false;
            }
        }
    }
}