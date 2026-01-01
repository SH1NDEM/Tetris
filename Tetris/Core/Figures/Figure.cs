using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    public class Figure
    {
        public FigureType Type { get; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public int[,] Shape => FigureShapes.Shapes[Type];

        public Figure(FigureType type, int startX, int startY)
        {
            Type = type;
            X = startX;
            Y = startY;
        }
    }
}
