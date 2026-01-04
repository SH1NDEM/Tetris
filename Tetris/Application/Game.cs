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

            // Создаём renderer
            _renderer = new ConsoleRenderer();

            while (true)
            {
                DateTime now = DateTime.Now;

                if ((now - lastFallTime).TotalSeconds >= 0.5)
                {

                    _figure.Y -= 1;
                    _field.FigureMove(_figure);
                    _field.FigureView(_figure);
                    _renderer.printGame();
                    lastFallTime = now;
                }

                if (_figure.Y == 1)
                {
                    _figure = newFig();
                }
            }
        }
    }
}
