namespace Tensor.Test.BubbleGame
{
    /// <summary>
    /// Точки
    /// </summary>
    public class Seed : GameUnit
    {
        public Seed(double x, double y, double Vx, double Vy)
            : base(x, y)
        {
            VelocityX = Vx;
            VelocityY = Vy;
        }

        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        /// <summary>
        /// Готовит данные для визуализатора
        /// </summary>
        /// <returns></returns>
        public override string Render()
        {
            return string.Format("seed {4} x: {0:F2}, y: {1:F2}, Vx: {2:F2}, Vy: {3:F2}", X, Y, VelocityX, VelocityY, UnitStatus);
        }

        public override void Evolute(double period)
        {
            if (UnitStatus != Status.Active) return;
            X += VelocityX * period;
            Y += VelocityY * period;
        }

        /// <summary>
        /// Столкновение с границами игрового поля
        /// </summary>
        /// <param name="gameUnit"></param>
        /// <param name="gameField"></param>
        public override bool Collision(GameUnit gameUnit, GameField gameField)
        {

            if (X < 0)
            {
                X = -X;
                VelocityX = -VelocityX;
            }
            if (X > gameField.Width)
            {
                X = gameField.Width;
                VelocityX = -VelocityX;
            }
            if (Y < 0)
            {
                Y = 0;
                VelocityY = -VelocityY;
            }
            if (Y > gameField.Width)
            {
                Y = gameField.Width;
                VelocityY = -VelocityY;
            }
            return false;
        }
    }
}
