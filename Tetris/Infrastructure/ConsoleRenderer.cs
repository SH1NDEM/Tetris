using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Core;

namespace Tetris.Infrastructure
{
    internal class ConsoleRenderer
    {
        char background = '·';
        char bottom = '=';
        string leftBorder = "<|";
        string rightBorder = "|>";

        int startConsoleX = 0 +10;
        int startConsoleY = 0 +3;
        int viewFieldHight = GameField.fieldHight - 5;

        void printBorders()
        {
            Console.SetCursorPosition(startConsoleX, startConsoleY);
            for (int i = 0; i < viewFieldHight; i++)
            {
                // Left border
                Console.SetCursorPosition(startConsoleX*2 + 1, startConsoleY + i);
                Console.Write(leftBorder);
            }

            for (int i = 0; i < viewFieldHight; i++)
            {
                // Right border
                Console.SetCursorPosition(startConsoleX  + (GameField.fieldWidth + 1) *3, startConsoleY + i);
                Console.Write(rightBorder);
            }
        }

        void printBottom()
        {
            for (int i = 0; i < (GameField.fieldWidth + 2) * 2; i++)
            {
                Console.SetCursorPosition(startConsoleX * 2 + i +1, startConsoleY + viewFieldHight);
                Console.Write(bottom);
            }
        }

        void printField()
        {
            for (int y = 0; y < viewFieldHight; y++)
            {
                for (int x = 0; x < GameField.fieldWidth; x++)
                {
                    int consoleX = startConsoleX + leftBorder.Length + x;
                    int consoleY = startConsoleY + viewFieldHight - 1 - y;

                    Console.SetCursorPosition(consoleX*2, consoleY);

                    bool cellOccupied = GameField.fieldMatrix[x, y];
                    Console.Write(cellOccupied ? '#' : background);
                }
            }
        }

        public void printGame()
        {
            printBorders();
            printBottom();
            printField();
        }
    }
}
