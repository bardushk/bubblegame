namespace Tensor.Test.BubbleGame
{
    /// <summary>
    /// Настройки игры
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Количество точек
        /// </summary>
        public int SeedCount { get; set; }

        /// <summary>
        /// Максимальный радиус пузыря
        /// </summary>
        public double MaxRadius { get; set; }

        /// <summary>
        /// Ширина игрового поля в безразмерных единицах
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Скорость точек
        /// </summary>
        public double Velocity { get; set; }
    }
}
