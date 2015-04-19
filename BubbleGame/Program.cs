using System;
namespace Tensor.Test.BubbleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var setting = new Settings() { Height = 100, Width = 100, MaxRadius = 10, SeedCount = 10, Velocity = 1 };
            var gameField = new GameField();
            IVisualizer visualizer = new ConsoleVisualizer();
            gameField.Init(setting);
            gameField.AddUnit(new Bubble(5, 5));
            var dateTime = DateTime.Now;
            do
            {
                var period = DateTime.Now.Subtract(dateTime);
                gameField.Evolute((double) period.Milliseconds / 1000);
                gameField.Collision();
                gameField.CheckStatus();
                visualizer.Render(gameField);
            }
            while (gameField.Status != GameField.GameStatus.GameOver);
        }
    }
}