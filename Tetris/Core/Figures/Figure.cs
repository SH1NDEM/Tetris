using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    public class Figure
    {
        private int _x;
        private int _y;

        public FigureType Type { get; }
        public int X
        {
            get { return _x; }

            set
            {
                if (value > 0 && value < 20)
                {
                    _x = value;
                }
            }
        }
        public int Y
        {
            get { return _y; }

            set
            {
                if (value > 0 && value < 20)
                {
                    _y = value;
                }
            }
        }

        public int[,] Shape => FigureShapes.Shapes[Type];

        public Figure(FigureType type, int startX, int startY)
        {
            Type = type;
            X = startX;
            Y = startY;
        }
    }
}
