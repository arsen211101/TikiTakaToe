using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikiTakaToe
{
    public class Board
    {
        static string[] board = new string[10] { "0", "1","2","3","4","5","6","7","8","9"};
        
        
        public Board()
        {

        }

        public bool input(string XorO, int index)
        {
            if (index <= 0 || index>9)
                return false;

            if (board[index] == "")
            {
                board[index] = XorO;
                return true;
            }

            return false;
        }

        private bool CheckWinner(int index0, int index1, int index2, string type)
        {
            return board[index0] == type && board[index1] == type && board[index2] == type;
        }


        public string WinnerCheck()
        {
            // 
            for(int j=1; j<4; j++)
            {
                if (CheckWinner(j,  j + 3,  j + 6, "X"))
                    return "X";

                if(CheckWinner(j, j + 3, j + 6, "O"))
                    return "O";
            }

            // Horizontal
            for (int j = 1; j < 8;)
            {
                if (CheckWinner(j, j + 1, j + 2, "X"))
                    return "X";

                if (CheckWinner(j, j + 1, j + 2, "O"))
                    return "O";

                j = j + 3;
            }
            
           
            if (CheckWinner(1, 5, 9, "X") || CheckWinner(7, 5, 3, "X"))
            {
                return "X";
            }
            

            if (CheckWinner(1, 5, 9, "O") || CheckWinner(7, 5, 3, "O")) 
            {
                return "O";
            }
            else
            {
                return "Draw";
            }
        }
    

        public void createBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = Convert.ToString(i);
            }
        }
        
        public void removeBoard()
        {
            for(int i=1;i<board.Length; i++){
                board[i] = "";
            }
        }

        public void Drowboard()
        {
            Console.WriteLine("   {0}  |  {1}  |  {2}  ", board[1], board[2], board[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", board[4], board[5], board[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", board[7], board[8], board[9]);
        }
    }
}
