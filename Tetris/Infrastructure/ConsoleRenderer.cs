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

        int startConsoleX = 0 +20;
        int startConsoleY = 0 +3;

        void printBorders()
        {
            Console.SetCursorPosition(startConsoleX, startConsoleY);
            for (int i = 0; i < GameField.fieldHight; i++)
            {
                // Left border
                Console.SetCursorPosition(startConsoleX, startConsoleY + i);
                Console.Write(leftBorder);
            }

            for (int i = 0; i < GameField.fieldHight; i++)
            {
                // Left border
                Console.SetCursorPosition(startConsoleX + GameField.fieldWidth + 2, startConsoleY + i);
                Console.Write(rightBorder);
            }
        }

        void printBottom()
        {
            for (int i = 0; i < GameField.fieldWidth + 4; i++)
            {
                Console.SetCursorPosition(startConsoleX + i, startConsoleY + GameField.fieldHight);
                Console.Write(bottom);
            }
        }

        void printField()
        {
            for (int y = 0; y < GameField.fieldHight; y++)
            {
                for (int x = 0; x < GameField.fieldWidth; x++)
                {
                    // ИСПРАВЛЕНО: раньше рисовалось в одной точке
                    // Преобразуем координаты Core (Y ↑) → Console (Y ↓)
                    int consoleX = startConsoleX + leftBorder.Length + x;
                    int consoleY = startConsoleY + GameField.fieldHight - 1 - y;

                    Console.SetCursorPosition(consoleX, consoleY);

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
