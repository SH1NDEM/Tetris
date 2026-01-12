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
            int[] per = new int [4];
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Game._field.borderCollision(figure, -1))
                        {
                            figure.X -= 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Game._field.borderCollision(figure, 1))
                        {
                            figure.X += 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        Game.speed = 0.05;
                        break;
                    case ConsoleKey.UpArrow:
                        for (int i = 0; i < 4; i++)
                        {
                            per[i] = figure.Shape[1, i];
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            figure.Shape[1, i] = figure.Shape[0, i];
                            figure.Shape[0, i] = -per[i];
                        }
                        break;

                }
            }
        }
    }
}
