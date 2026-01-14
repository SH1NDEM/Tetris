using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Core.Figures;

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
                if (value >= 0 && value < 10)
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
        public int[,] Shape { get; private set; }

        public ConsoleColor Colour { get; private set; }

        private static int[,] CloneMatrix(int[,] source)
        {
            var result = new int[source.GetLength(0), source.GetLength(1)];
            Array.Copy(source, result, source.Length);
            return result;
        }

        /// <summary>
        /// Конструктор фигуры
        /// </summary>
        /// <param name="type">форма фигуры</param>
        /// <param name="startX">координата по X</param>
        /// <param name="startY">координата по Y</param>
        public Figure(FigureType type, int startX, int startY)
        {
            Type = type;
            Shape = CloneMatrix(FigureShapes.Shapes[type]);
            Colour = FigureColours.Colour[type];
            X = startX;
            Y = startY;
        }
    }
}
