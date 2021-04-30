using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikiTakaToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board obekt = new Board();

            StartGame();

            void StartGame()
            {
                string player1, player2, activePlayer, XorO, WinnerCheck, menuEnter, position;
                int posOut;
                bool inputValidation = false;
                bool positionValidation;

                while (true)
                {
                    Console.Write("Please: \n" + "enter 0-for exit;\n" + "enter 1 for start;\n");
                    menuEnter = Console.ReadLine();

                    switch (menuEnter)
                    {
                        case "0":
                            Console.WriteLine("Thank you and goodbye!");
                            return;

                        case "1":
                            Console.Write("Welcome to Tiki Taka \n" + "Plear 1 Please enter your name :\n");
                            player1 = Console.ReadLine();

                            Console.Write("So, We can start after Player 2 will enter his name. \n Please fill your name: ");
                            player2 = Console.ReadLine();

                            Console.Write("Great! {0} you are playing with X so {1} -you are playing with (O) . \n", player1, player2);
                            Console.Write("Here is the board:\n");
                            obekt.createBoard();
                            obekt.Drowboard();


                            Console.Write("Lets start! \n");
                            obekt.removeBoard();

                            for (int i = 0; i < 9; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    XorO = "X";
                                    activePlayer = player1;
                                }
                                else
                                {
                                    XorO = "O";
                                    activePlayer = player2;
                                }

                                do
                                {
                                    Console.Write("Dear {0} please select position number where you would like to mark {1}, \n " + " Please be sure that position is valid and you can use it \n " + " Good Luck!.\n ", activePlayer, XorO);
                                    position = Console.ReadLine();
                                    positionValidation = Int32.TryParse(position, out posOut);

                                    if (positionValidation == false || posOut <= 0 || posOut > 9)
                                        Console.Write("Please enter valid position.\n");
                                    else
                                    {
                                        inputValidation = obekt.input(XorO, posOut);
                                        if (inputValidation == false)
                                            Console.Write("This position is marked! \n");
                                    }

                                    obekt.Drowboard();
                                } while (positionValidation == false || inputValidation == false);

                                inputValidation = false;

                                if (i >= 4)
                                {
                                    WinnerCheck = obekt.WinnerCheck();

                                    if (WinnerCheck == "X" || WinnerCheck == "O" || WinnerCheck == "Nichya")
                                    {
                                        if (WinnerCheck == "X")
                                            Console.Write("Wooow! Winner Winner Chicken Dinner! {0}-@, Congrats! You are our winner.\n", player1);

                                        else if (WinnerCheck == "O")
                                            Console.Write("Wooow! Winner Winner Chicken Dinner! {0}-@, Congrats! You are our winner. \n", player2);
                                        else
                                            Console.Write("oooh. That draw!! Try again. Other one will be lucky game for you! \n");
                                        break;
                                    }
                               
                                }
                            }
                            break;

                        default:
                            Console.Write("Please enter number.\n");
                            break;
                    }
                }
            }


        }
    }
}
