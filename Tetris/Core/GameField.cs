using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
        private bool[,] _fieldMatrix = new bool[fieldWidth, fieldHight];
        public bool[,] FieldMatrix => _fieldMatrix;

        /// <summary>
        /// Полная очистка fieldMatrix
        /// </summary>
        public void ClearField()
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                for (int y = 0; y < fieldHight; y++)
                {
                    FieldMatrix[x, y] = false;
                }
            }
        }

        /// <summary>
        /// Отображение падающей фигуры
        /// </summary>
        /// <param name="figure"></param>
        public void FigureView(Figure figure)
        {
            int x = figure.X;
            int y = figure.Y;

            for (int i = 0; i < 4; i++)
            {
                int fieldX = x + figure.Shape[0, i];
                int fieldY = y + figure.Shape[1, i];

                FieldMatrix[fieldX, fieldY] = true;
            }
        }

        /// <summary>
        /// Удаление предыдущих кадров падающей фигуры
        /// </summary>
        /// <param name="figure"></param>
        public void FigureClear(Figure figure)
        {
            int x = figure.X;
            int y = figure.Y;

            for (int i = 0; i < 4; i++)
            {
                int fieldX = x + figure.Shape[0, i];
                int fieldY = y + figure.Shape[1, i];

                FieldMatrix[fieldX, fieldY] = false;
            }
        }

        /// <summary>
        /// Функция показывающая коллизию фигуры в следующем тике
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool fallingCollision(Figure figure)
        {
            for (int i = 0; i < 4; i++)
            {
                int fieldX = figure.X + figure.Shape[0, i];
                int fieldY = figure.Y + figure.Shape[1, i] - 1; ;
                
                // границы поля
                if (fieldX < 0 || fieldX >= fieldWidth || fieldY < 1)
                    return false; // коллизия

                // столкновение с зафиксированными блоками
                if (FieldMatrix[fieldX, fieldY])
                    return false; // коллизия
            }
            return true; // можно падать
        }

        public bool CanRotate(Figure figure)
        {
            for (int i = 0; i < 4; i++)
            {
                // будущие координаты после поворота
                int newX = -figure.Shape[1, i];
                int newY = figure.Shape[0, i];

                int fieldX = figure.X + newX;
                int fieldY = figure.Y + newY;

                if (fieldX < 0 || fieldX >= fieldWidth ||
                    fieldY < 0 || fieldY >= fieldHight)
                {
                    return false;
                }

                if (FieldMatrix[fieldX, fieldY])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Сравнение возможности сдвинуть фигуру вбок и не перезаписть ячейку другой фигуры
        /// </summary>
        /// <param name="figure">фигура сравнения</param>
        /// <param name="step">шаг вправо и влево (1, -1)</param>
        /// <returns></returns>
        public bool BorderCollision(Figure figure, int step)
        {
            for (int i = 0; i < 4; i++)
            {
                int fieldX = figure.X + figure.Shape[0, i] + step;
                int fieldY = figure.Y + figure.Shape[1, i];

                // выход за границы поля
                if (fieldX < 0 || fieldX >= fieldWidth ||
                    fieldY < 0 || fieldY >= fieldHight)
                {
                    return false;
                }

                // столкновение с занятой клеткой
                if (FieldMatrix[fieldX, fieldY])
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Стирает полную линию y и сдвигает всё выше неё вниз
        /// </summary>
        /// <param name="y"></param>
        private void ClearLine(int y)
        {
            for (int row = y; row < fieldHight - 1; row++)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    FieldMatrix[x, row] = FieldMatrix[x, row + 1];
                }
            }

            // Очищаем верхнюю строку
            for (int x = 0; x < fieldWidth; x++)
            {
                FieldMatrix[x, fieldHight - 1] = false;
            }
        }

        public bool IsLineFull(int y)
        {
            for (int x = 0; x < fieldWidth; x++)
                if (!FieldMatrix[x, y])
                    return false;
            return true;
        }

        public int CheckFullLines()
        {
            int count = 0;
            for (int y = fieldHight - 1; y >= 0; y--)
            {
                if (IsLineFull(y))
                {
                    ClearLine(y);
                    count++;
                    y++; // Проверяем эту же строку снова после сдвига
                }
            }
            return count*100;
        }

        public bool GameOver()
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                if (FieldMatrix[x, 20] == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
