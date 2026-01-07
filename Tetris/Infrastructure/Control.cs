using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Core;
using Tetris.Application;

namespace Tetris.Infrastructure
{
    internal class Control
    {
        public void figureControl(Figure figure) 
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        figure.X -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        figure.X += 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Game.speed = 0.1;
                        break;
                }
            }
        }
    }
}
