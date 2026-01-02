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

            _figure = new Figure(FigureType.Z, 5, 19);
            _field.FigureView(_figure);
            _field.ClearField();
            _field.FigureView(_figure);
            _renderer.printGame();
        }

        public async void Run()
        {
            DateTime lastFallTime = DateTime.Now;
            // Создаём renderer
            _renderer = new ConsoleRenderer();

            _figure = new Figure(FigureType.Z, 5, 19);
            //_field.FigureView(_figure);
            //_field.ClearField();
            //_renderer.printGame();

            int Y = 19;
            while (true)
            {
                DateTime now = DateTime.Now;
                //_figure = new Figure(FigureType.Z, 5, 19);

                if ((now - lastFallTime).TotalSeconds >= 0.5)
                {
                    
                    _figure.Y -= 1;
                    //_field.FigureView(_figure);
                    //_field.ClearField();
                    _field.FigureMove(_figure);
                    _field.FigureView(_figure);
                    _renderer.printGame();
                    lastFallTime = now;
                    Y -= 1;
                    
                }
                if (Y == 0 || (GameField.fieldMatrix[_figure.X, _figure.Y - 1]) == true)
                {
                    _figure = new Figure(FigureType.Z, 5, 19);
                }
            }
        }
    }
}
