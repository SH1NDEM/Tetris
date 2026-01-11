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

                fieldMatrix[fieldX, fieldY] = true;
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

                fieldMatrix[fieldX, fieldY] = false;
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
                if (fieldX < 0 || fieldX >= GameField.fieldWidth || fieldY < 1)
                    return false; // коллизия

                // столкновение с зафиксированными блоками
                if (GameField.fieldMatrix[fieldX, fieldY])
                    return false; // коллизия
            }
            return true; // можно падать
        }

        /// <summary>
        /// Сравнение возможности сдвинуть фигуру вбок и не перезаписть ячейку другой фигуры
        /// </summary>
        /// <param name="figure">фигура сравнения</param>
        /// <param name="step">шаг вправо и влево (1, -1)</param>
        /// <returns></returns>
        public bool borderCollision(Figure figure, int step)
        {
            int x = figure.X;
            int y = figure.Y;

            for (int i = 0; i < 4; i++)
            {
                int fieldX = x + figure.Shape[0, i] ;
                int fieldY = y + figure.Shape[1, i];

                if (fieldMatrix[fieldX + step, fieldY] == true)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsLineFull(int y)
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                if (!fieldMatrix[x, y])
                    return false;
            }
            return true;
        }

        public void ClearLine(int y)
        {
            // сдвигаем ВСЕ строки выше вниз
            for (int yy = y; yy > 0; yy--)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    fieldMatrix[x, yy] = fieldMatrix[x, yy - 1];
                }
            }

            // верхнюю строку очищаем
            for (int x = 0; x < fieldWidth; x++)
            {
                fieldMatrix[x, 0] = false;
            }
        }



        public void CheckFullLines()
        {
            for (int y = fieldHight - 1; y >= 0; y--)
            {
                if (IsLineFull(y))
                {
                    ClearLine(y);
                    y++; // перепроверяем эту же строку
                }
            }
        }

    }
}
