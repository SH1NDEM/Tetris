using System.Diagnostics;
using Tetris.Core;
using Tetris.Infrastructure;

namespace Tetris.Application
{
    internal class Game
    {
        public static double speed = 0.7;
        public static GameField _field;
        public static int score = 0;
        private ConsoleRenderer _renderer;
        private Figure _figure;
        private Figure _figureNext;
        private Control _control;
        private static readonly Random _rnd = new Random();

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
        }

        /// <summary>
        /// Создание случайной фигуры
        /// </summary>
        /// <returns>Figure(5, 20)</returns>
        public Figure newFig()
        {
            Array values = Enum.GetValues(typeof(FigureType));
            FigureType randomType = (FigureType)values.GetValue(_rnd.Next(values.Length));

            //создание падающей фигуры
            return new Figure(randomType, 5, 20);
        }

        /// <summary>
        /// Запуск игрового процесса
        /// </summary>
        public async Task Run()
        {
            _figure = newFig();
            _figureNext = newFig();

            DateTime lastFallTime = DateTime.Now;

            _renderer.Init();

            while (true)
            {
                DateTime now = DateTime.Now;
                _field.FigureClear(_figure);
                _control.figureControl(_figure);

                if ((now - lastFallTime).TotalSeconds < speed)
                {
                    _field.FigureView(_figure);
                    _renderer.printGame(_figureNext, score, _field.FieldMatrix);
                }
                else
                {
                    _figure.Y -= 1;
                    if (!_field.fallingCollision(_figure))
                    {
                        _field.FigureView(_figure);
                        score += _field.CheckFullLines();
                        _figure = _figureNext;
                        _renderer.ClearNextFigure(_figureNext);
                        if (_field.GameOver())
                        {
                            _renderer.PrintGameOver(score);
                            Console.Read();
                            Process.GetCurrentProcess().Kill();
                        }
                        _figureNext = newFig();
                    }
                    else
                    {
                        _field.FigureView(_figure);
                    }
                    _renderer.printGame(_figureNext, score, _field.FieldMatrix);
                    lastFallTime = now;
                    speed = 0.7;
                }

                await Task.Delay(16);
            }
        }
    }
}
