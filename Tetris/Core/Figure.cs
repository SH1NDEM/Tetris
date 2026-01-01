using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    internal class Figure
    {
        int[,] TFigure = { {0,-1, 0, 1}, {0, 0, 1, 0} };
        int[,] OFigure = { {0, 0, 1, 1}, {0, 1, 1, 0} };
        int[,] IFigure = { {0, 0, 0, 0}, {0, 1, 2,-1} };
        int[,] SFigure = { {0, 1,-1, 0}, {0, 0,-1,-1} };
        int[,] ZFigure = { {0,-1, 0, 1}, {0, 0,-1,-1} };
        int[,] LFigure = { {0, 0, 0, 1}, {1, 0,-1,-1} };
        int[,] JFigure = { {0, 0, 0,-1}, {1, 0,-1,-1} };
    }
}
