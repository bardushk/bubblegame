using System;

namespace Tensor.Test.BubbleGame
{
    class ConsoleVisualizer : IVisualizer
    {
        public void Render(GameField gameField)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(gameField.Render());
        }
    }
}
