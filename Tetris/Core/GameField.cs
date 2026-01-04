using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    internal class GameField
    {
        /// <summary>
        /// Высота игрового поля (20 видимого и 5 невидимого)
        /// </summary>
        readonly public static int fieldHight = 25;
        /// <summary>
        /// Ширина игрового поля 
        /// </summary>
        readonly public static int fieldWidth = 10;

        /// <summary>
        /// Матрица поля типа bool
        /// </summary>
        public static bool[,] fieldMatrix = new bool[fieldWidth, fieldHight];

        /// <summary>
        /// Полная очистка fieldMatrix
        /// </summary>
        public void ClearField()
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                for (int y = 0; y < fieldHight; y++)
                {
                    fieldMatrix[x, y] = false;
                }
            }
        }

        public void FigureView(Figure figure)
        {
            int x = figure.X;
            int y = figure.Y;

            for (int i = 0; i < 4; i++)
            {
                int fieldX = x + figure.Shape[0, i];
                int fieldY = y + figure.Shape[1, i];

                fieldMatrix[fieldX, fieldY] = true;
            }
        }


        public void FigureMove(Figure figure)
        {
            int x = figure.X;
            int y = figure.Y;

            for (int i = 0; i < 4; i++)
            {
                int fieldX = x + figure.Shape[0, i] ;
                int fieldY = y + figure.Shape[1, i] + 1;

                fieldMatrix[fieldX, fieldY] = false;
            }
        }

        public bool fallingCollision(Figure figure)
        {
            for (int i = 0; i < 4; i++)
            {
                int fieldX = figure.X + figure.Shape[0, i];
                int fieldY = 0;
                switch (figure.Type)
                {
                    case FigureType.I:
                        {
                            fieldY = figure.Y + figure.Shape[1, i] - 3;
                            break;
                        }
                    case FigureType.O:
                        {
                            fieldY = figure.Y + figure.Shape[1, i] - 1;
                            break;
                        }
                    case FigureType.T:
                        {
                            fieldY = figure.Y + figure.Shape[1, i] - 1;
                            break;
                        }
                    case FigureType.S:
                        {
                            fieldY = figure.Y + figure.Shape[1, i] - 1;
                            break;
                        }
                    case FigureType.Z:
                        {
                            fieldY = figure.Y + figure.Shape[1, i] - 1;
                            break;
                        }
                    case FigureType.L:
                        {
                            fieldY = figure.Y + figure.Shape[1, i] - 2;
                            break;
                        }
                    case FigureType.J:
                        {
                            fieldY = figure.Y + figure.Shape[1, i] - 2;
                            break;
                        }
                }
                // границы поля
                if (fieldX < 0 || fieldX >= GameField.fieldWidth || fieldY < 0)
                    return false; // коллизия

                // столкновение с зафиксированными блоками
                if (GameField.fieldMatrix[fieldX, fieldY])
                    return false; // коллизия

            }

            return true; // можно падать
        }
    }
}
