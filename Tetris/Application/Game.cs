using Tetris.Core;
using Tetris.Infrastructure;

namespace Tetris.Application
{
    internal class Game
    {
        private GameField _field;
        private ConsoleRenderer _renderer;
        private Figure _figure;

        /// <summary>
        /// Сздание объектов GameField, ConsoleRenderer. <br/>
        /// Очистка и отображение поля
        /// </summary>
        public Game()
        {
            _field = new GameField();
            _renderer = new ConsoleRenderer();
            _field.ClearField();
            _renderer.printGame();
        }

        /// <summary>
        /// Создание случайной фигуры
        /// </summary>
        /// <returns>Figure(5, 22)</returns>
        public Figure newFig()
        {
            Random rnd = new Random();

            Array values = Enum.GetValues(typeof(FigureType));
            FigureType randomType = (FigureType)values.GetValue(rnd.Next(values.Length));

            //создание падающей фигуры
            return new Figure(randomType, 5, 22);
        }

        /// <summary>
        /// Запуск игрового процесса
        /// </summary>
        public async void Run()
        {
            _figure = newFig();

            DateTime lastFallTime = DateTime.Now;

            // Создаём renderer
            _renderer = new ConsoleRenderer();

            while (true)
            {
                DateTime now = DateTime.Now;

                if ((now - lastFallTime).TotalSeconds >= 0.1)
                {
                    _field.FigureClear(_figure);

                    if (!_field.fallingCollision(_figure))
                    {
                        _field.FigureView(_figure);
                        _figure = newFig();
                    }
                    else
                    {
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
