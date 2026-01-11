using Tetris.Core;
using Tetris.Infrastructure;

namespace Tetris.Application
{
    internal class Game
    {
        public static double speed = 0.7;
        public static GameField _field;
        private ConsoleRenderer _renderer;
        private Figure _figure;
        private Control _control;

        /// <summary>
        /// Сздание объектов GameField, ConsoleRenderer. <br/>
        /// Очистка и отображение поля
        /// </summary>
        public Game()
        {
            _field = new GameField();
            _renderer = new ConsoleRenderer();
            _control = new Control();
            _field.ClearField();
            _renderer.printGame();
        }

        /// <summary>
        /// Создание случайной фигуры
        /// </summary>
        /// <returns>Figure(5, 20)</returns>
        public Figure newFig()
        {
            Random rnd = new Random();

            Array values = Enum.GetValues(typeof(FigureType));
            FigureType randomType = (FigureType)values.GetValue(rnd.Next(values.Length));

            //создание падающей фигуры
            return new Figure(randomType, 5, 20);
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
                _field.FigureClear(_figure);
                _control.figureControl(_figure);

                if ((now - lastFallTime).TotalSeconds < speed )
                {
                    _field.FigureView(_figure);
                    _renderer.printGame();
                }

                else if ((now - lastFallTime).TotalSeconds >= speed)
                {
                    _figure.Y -= 1;
                    if (!_field.fallingCollision(_figure))
                    {
                        _field.FigureView(_figure);
                        _field.CheckFullLines();
                        _figure = newFig();
                    }
                    else
                    {
                        _field.FigureView(_figure);
                    }
                    _renderer.printGame();
                    lastFallTime = now;
                    speed = 0.7;
                }
            }
        }
    }
}
