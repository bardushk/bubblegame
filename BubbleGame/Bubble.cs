namespace Tensor.Test.BubbleGame
{
    /// <summary>
    /// Пузыри
    /// </summary>
    public class Bubble : GameUnit
    {
        double _age;
        double MAX_AGE = 2000;
        double GROW_SPEED = 0.1;
        double MAX_RADIUS = 10;


        public Bubble() : base()
        {
            _age = 0;
            Size = 0;
        }

        public Bubble(double x, double y) : base(x, y)
        {
            _age = 0;
            Size = 0;
        }

        public override string Render()
        {
            return string.Format("{3} {4} x: {0:F2} y: {1:F2}, radius: {2:F2}", X, Y, Size, this.GetType().Name, UnitStatus);
        }

        public override void Evolute(double period)
        {
            if (UnitStatus == Status.Passive) return;
            if (_age < MAX_AGE)
            {

                _age += period;
                Size = Size < MAX_RADIUS ?_age * GROW_SPEED : 0;
                return;
            }
            UnitStatus = Status.Passive;
        }

        /// <summary>
        /// Поглощение частицы
        /// </summary>
        /// <param name="gameUnit"></param>
        /// <param name="gameField"></param>
        public override bool Collision(GameUnit gameUnit, GameField gameField)
        {
            if (gameUnit.UnitStatus == Status.Passive) return false;
            if (gameUnit == this) return false;
            if (gameUnit.GetType() == this.GetType()) return false; // Столкновения между пызырями не учитываем 
            if ((gameUnit.X - X) * (gameUnit.X - X) + (gameUnit.Y - Y) * (gameUnit.Y - Y) <= Size * Size)
            {                                
                gameUnit.UnitStatus = Status.Passive;
                gameField.AddUnit(new Bubble( gameUnit.X, gameUnit.Y ));
                return true;
            }
            return false;
        }
    }
}
