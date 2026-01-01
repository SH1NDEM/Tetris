using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    internal class GameField
    {
        readonly public static int fieldHight = 20;
        readonly public static int fieldWidth = 10 * 2;

        bool[,] fieldMatrix = new bool[fieldWidth, fieldHight];

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
    }
}
