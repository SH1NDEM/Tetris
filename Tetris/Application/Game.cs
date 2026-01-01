using Tetris.Core;
using Tetris.Infrastructure;

namespace Tetris.Application
{
    internal class Game
    {
        private readonly GameField _field;
        private readonly ConsoleRenderer _renderer;

        public Game()
        {
            // Создаём игровое поле
            _field = new GameField();
            _field.ClearField(); // Инициализация пустого поля

            // Создаём renderer
            _renderer = new ConsoleRenderer();
        }

        public void Run()
        {
            // Первый тик игры — просто отрисовка пустого поля
            _renderer.printField();

            // Здесь позже будет игровой цикл
            // Например: while(running) { Update(); _renderer.PrintField(_field); }
            Console.ReadLine();
        }
    }
}
