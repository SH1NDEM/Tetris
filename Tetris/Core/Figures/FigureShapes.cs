using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    internal class FigureShapes
    {
        public static readonly Dictionary<FigureType, int[,]> Shapes = new()
        {
            { FigureType.T, new int[,] { {0,-1, 0, 1}, {0, 0, 1, 0} } },
            { FigureType.O, new int[,] { {0, 0, 1, 1}, {0, 1, 1, 0} } },
            { FigureType.I, new int[,] { {0, 0, 0, 0}, {0, 1, 2,-1} } },
            { FigureType.S, new int[,] { {0, 1,-1, 0}, {0, 0,-1,-1} } },
            { FigureType.Z, new int[,] { {0,-1, 0, 1}, {0, 0,-1,-1} } },
            { FigureType.L, new int[,] { {0, 0, 0, 1}, {1, 0,-1,-1} } },
            { FigureType.J, new int[,] { {0, 0, 0,-1}, {1, 0,-1,-1} } }

        };
    }
}
