using Tetris.Application;

internal class Program
{
    private static async Task Main()
    {
        // Создаём игру
        var game = new Game();

        // Запускаем игру
        await game.Run();
    }
}
