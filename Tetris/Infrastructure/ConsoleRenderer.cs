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

        void ViewNextFigure(Figure figure)
        {
            int[,] shape = FigureShapes.Shapes[figure.Type];

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition((-(shape[0, i] )+ 25) * 2, shape[1, i] + 6);
                Console.Write('#');
            }
        }


        public void ClearNextFigure(Figure figure)
        {
            int[,] shape = FigureShapes.Shapes[figure.Type];

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition((-(shape[0, i]) + 25) * 2, shape[1, i] + 6);
                Console.Write(' ');
            }
        }

        void ShowScore(int score)
        {
            Console.SetCursorPosition(48, 3);
            Console.Write("score: ");
            Console.SetCursorPosition(55, 3);
            Console.Write(score);
        }

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

        void printField(bool[,] fieldMatrix)
        {
            for (int y = 1; y < viewFieldHight+1; y++)
            {
                for (int x = 0; x < GameField.fieldWidth; x++)
                {
                    int consoleX = startConsoleX + leftBorder.Length + x;
                    int consoleY = startConsoleY + viewFieldHight  - y;

                    Console.SetCursorPosition(consoleX*2, consoleY);

                    bool cellOccupied = fieldMatrix[x, y];
                    Console.Write(cellOccupied ? '#' : background);
                }
            }
        }

        public void PrintGameOver(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(52, 3);
            Console.Write("█▀▀ ▄▀█ █▀▄▀█ █▀▀");
            Console.SetCursorPosition(52, 4);
            Console.Write("█▄█ █▀█ █ ▀ █ ██▄");
            Console.SetCursorPosition(52, 6);
            Console.Write("█▀█ █ █ █▀▀ █▀█");
            Console.SetCursorPosition(52, 7);
            Console.Write("█▄█ ▀▄▀ ██▄ █▀▄");
            Console.SetCursorPosition(52, 9);
            Console.Write("Your score: ");
            Console.SetCursorPosition(64, 9);
            Console.Write(score);
        }
        public void Init()
        {
            Console.CursorVisible = false;
            printBorders();
            printBottom();
        }

        public void printGame(Figure figure, int score, bool[,] fieldMatrix)
        {
            printField(fieldMatrix);
            ViewNextFigure(figure);
            ShowScore(score);
        }
    }
}
