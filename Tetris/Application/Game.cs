using Tetris.Core;
using Tetris.Infrastructure;

namespace Tetris.Application
{
    internal class Game
    {
        private GameField _field;
        private ConsoleRenderer _renderer;
        private Figure _figure;

        public Game()
        {
            _field = new GameField();
            _renderer = new ConsoleRenderer();
            _field.ClearField();
            _renderer.printGame();
            
        }

        public Figure newFig()
        {
            Random rnd = new Random();

            Array values = Enum.GetValues(typeof(FigureType));
            FigureType randomType = (FigureType)values.GetValue(rnd.Next(values.Length));

            //создание падающей фигуры
            return new Figure(randomType, 5, 21);
        }

        public async void Run()
        {
            _figure = newFig();
            DateTime lastFallTime = DateTime.Now;

            while (true)
            {
                DateTime now = DateTime.Now;

                if ((now - lastFallTime).TotalSeconds >= 0.1)
                {

                    if (_field.fallingCollision(_figure))
                    {
                        // стерли старую позицию
                        _field.FigureMove(_figure);

                        // нарисовали новую позицию
                        _field.FigureView(_figure);
                    }
                    else
                    {
                        // фигура зафиксирована, создаём новую
                        _figure = newFig();
                        _field.FigureView(_figure);
                    }
                    _figure.Y -= 1;
                    _renderer.printGame();
                    lastFallTime = now;
                }
            }
        }

    }
}
