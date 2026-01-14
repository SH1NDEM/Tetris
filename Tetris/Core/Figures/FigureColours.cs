using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core.Figures
{
    internal class FigureColours
    {
        public static readonly Dictionary<FigureType, ConsoleColor> Colour = new()
        {
            { FigureType.T, ConsoleColor.Yellow},   //yellow
            { FigureType.O, ConsoleColor.Blue},     //blue
            { FigureType.I, ConsoleColor.Red},      //red
            { FigureType.S, ConsoleColor.Green},    //green
            { FigureType.Z, ConsoleColor.Cyan},     //turquoise
            { FigureType.L, ConsoleColor.Magenta},  //pink
            { FigureType.J, ConsoleColor.DarkGray}  //DarkGray
        };
    }
}
