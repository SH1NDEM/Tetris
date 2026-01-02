using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    internal class GameField
    {
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        readonly public static int fieldHight = 20;
        /// <summary>
        /// Ширина игрового поля (*2 для лучшего отображения)
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

        public void FigureMovement(Figure figure)
        {

        }
    }
}
