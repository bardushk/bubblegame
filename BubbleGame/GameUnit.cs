namespace Tensor.Test.BubbleGame
{
    /// <summary>
    /// Абстрактный базовый класс для точек и пузырей
    /// </summary>
    public abstract class GameUnit
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Size { get; set; }

        public GameUnit()
        {
            UnitStatus = Status.Active;
        }

        public GameUnit(double x, double y) : this() 
        {
            X = x;
            Y = y;
        }

        public Status UnitStatus { get; set; }

        /// <summary>
        /// Готовоит к объект к передачи в визуализатор
        /// </summary>
        /// <returns></returns>
        public abstract string Render();
        
        /// <summary>
        /// Для точек - перемещение, для пузыря рост
        /// </summary>
        /// <param name="period"></param>
        public abstract void Evolute(double period);

        /// <summary>
        /// Проверяет на столкновения
        /// </summary>
        /// <param name="gameUnit"></param>
        /// <param name="gameField"></param>
        public abstract bool Collision(GameUnit gameUnit, GameField gameField);
    }
    /// <summary>
    /// Два возможных состояния для точки и пузыря
    /// </summary>
    public enum Status { Active, Passive };
}
