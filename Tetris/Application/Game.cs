using Tetris.Core;
using Tetris.Infrastructure;

namespace Tetris.Application
{
    internal class Game
    {
        private readonly GameField _field;
        private readonly ConsoleRenderer _renderer;
        private readonly Figure _figure;

        public Game()
        {
            // Создаём игровое поле
            _field = new GameField();
            _figure = new Figure(FigureType.Z, 5, 10);
            _field.ClearField(); // Инициализация пустого поля
            _field.FigureMovment(_figure);

            // Создаём renderer
            _renderer = new ConsoleRenderer();
        }

        public void Run()
        {
            // Первый тик игры — просто отрисовка пустого поля
            _renderer.printGame();

            // Здесь позже будет игровой цикл
            // Например: while(running) { Update(); _renderer.PrintField(_field); }
            Console.ReadLine();
        }
    }
}
