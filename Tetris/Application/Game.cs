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
        }

        public async void Run()
        {
            DateTime lastFallTime = DateTime.Now;
            // Создаём renderer
            _renderer = new ConsoleRenderer();

            _figure = new Figure(FigureType.Z, 5, 19);
            _field.FigureMovment(_figure);

            int Y = 19;
            while (true)
            {
                DateTime now = DateTime.Now;

                if ((now - lastFallTime).TotalSeconds >= 0.5)
                {
                    _field.ClearField();
                    _figure = new Figure(FigureType.Z, 5, Y);
                    _field.FigureMovment(_figure);
                    lastFallTime = now;
                    Y -= 1;
                    _renderer.printGame();
                }
                if (Y == 0)
                {

                }
            }
        }
    }
}
