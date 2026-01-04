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
            return countOfCollision(figure, 0, -1) == 0;
        }


        public int countOfCollision(Figure figure, int xp, int yp)
        {
            int count = 0;

            for (int i = 0; i < 4; i++)
            {
                int fieldX = figure.X + figure.Shape[0, i] + xp;
                int fieldY = figure.Y + figure.Shape[1, i] + yp;

                // выход за границы поля
                if (fieldX < 0 || fieldX >= fieldWidth || fieldY < 0)
                {
                    count++;
                    continue;
                }

                // столкновение с занятым блоком
                if (fieldMatrix[fieldX, fieldY])
                {
                    count++;
                }
            }
            return count;
        }

    }
}
