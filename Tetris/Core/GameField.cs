using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
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
        public static int[,] fieldMatrix = new int[fieldWidth, fieldHight];

        /// <summary>
        /// Полная очистка fieldMatrix
        /// </summary>
        public void ClearField()
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                for (int y = 0; y < fieldHight; y++)
                {
                    fieldMatrix[x, y] = 0;
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

                fieldMatrix[fieldX, fieldY] = (int)figure.Colour;
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

                fieldMatrix[fieldX, fieldY] = 0;
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
                if (fieldMatrix[fieldX, fieldY] > 0)
                    return false; // коллизия
            }
            return true; // можно падать
        }

        /// <summary>
        /// Булевое обозначение возможности вращения фигуры
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
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

                if (fieldMatrix[fieldX, fieldY] > 0)
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
                if (fieldMatrix[fieldX, fieldY] > 0)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Опускает все строки выше удаленных вниз
        /// </summary>
        private void AllLineDown()
        {
            for (int y = 0; y < fieldHight - 1; y++) // начинаем с нижней строки
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    fieldMatrix[x, y] = fieldMatrix[x, y + 1]; // берём строку сверху и сдвигаем вниз
                }
            }
        }

        /// <summary>
        /// Стирает полные линии
        /// </summary>
        /// <param name="y"></param>
        private void ClearLine(int y)
        {
            for (int yy = y; yy > 0; yy--)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    fieldMatrix[x, yy] = fieldMatrix[x, yy - 1];
                }
            }

            // Очищаем верхнюю строку
            for (int x = 0; x < fieldWidth; x++)
            {
                fieldMatrix[x, 0] = 0;
            }
        }

        /// <summary>
        /// Булевое значение заполненности линии
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsLineFull(int y)
        {
            for (int x = 0; x < fieldWidth; x++)
                if (fieldMatrix[x, y] == 0)
                    return false;
            return true;
        }

        /// <summary>
        /// Проверка и удаление полных линий
        /// </summary>
        /// <returns></returns>
        public int CheckFullLines()
        {
            int count = 0;
            for (int y = fieldHight - 1; y >= 0; y--)
            {
                if (IsLineFull(y))
                {
                    ClearLine(y);
                    AllLineDown();
                    count++;
                    y++; // Проверяем эту же строку снова после сдвига
                }
            }
            return count*100;
        }

        /// <summary>
        /// Булевое значение окончания игры
        /// </summary>
        /// <returns></returns>
        public bool GameOver()
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                if (fieldMatrix[x, 20] > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
