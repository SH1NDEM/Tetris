using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    public class Figure
    {
        /// <summary>
        /// Координата фигуры по X
        /// </summary>
        private int _x;
        /// <summary>
        /// Координата фигуры по Y
        /// </summary>
        private int _y;

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public FigureType Type { get; }
        public int X
        {
            get { return _x; }

            set
            {
                if (value >= 0 && value < 9)
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
                if (value > 0 && value < 25)
                {
                    _y = value;
                }
            }
        }
        public int[,] Shape => FigureShapes.Shapes[Type];

        /// <summary>
        /// Конструктор фигуры
        /// </summary>
        /// <param name="type">форма фигуры</param>
        /// <param name="startX">координата по X</param>
        /// <param name="startY">координата по Y</param>
        public Figure(FigureType type, int startX, int startY)
        {
            Type = type;
            X = startX;
            Y = startY;
        }
    }
}
