using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tensor.Test.BubbleGame
{
    /// <summary>
    /// Игровое поле
    /// </summary>
    public class GameField
    {
        public GameStatus Status { get; set; }

        public double Width
        {
            get
            {
                return _settings.Width;
            }
        }

        public double Height
        {
            get
            {
                return _settings.Height;
            }
        }

        List<GameUnit> _units = new List<GameUnit>();
        Settings _settings;

        /// <summary>
        /// Распределяет точки по игровому полю
        /// </summary>
        /// <param name="settings"></param>
        public void Init(Settings settings)
        {
            _settings = settings;
            var random = new Random();
            for (int i = 0; i < _settings.SeedCount; i++)
            {
                var x = random.NextDouble() * _settings.Width;
                var y = random.NextDouble() * _settings.Height;
                var direction = random.NextDouble() * Math.PI;
                var vx = _settings.Velocity * Math.Sin(direction);
                var vy = _settings.Velocity * Math.Cos(direction);

                _units.Add(new Seed(x, y, vx, vy));
            }
            Status = GameStatus.Play;
        }

        /// <summary>
        /// Добавляет новую частицу (или пузырь)
        /// </summary>
        /// <param name="unit"></param>
        public void AddUnit(GameUnit unit)
        {
            _units.Add(unit);
        }

        /// <summary>
        /// Готовит данные игрового поля для передачи в визуализатор
        /// </summary>
        public string Render()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in _units)
            {
                stringBuilder.AppendLine(item.Render());
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Шаг игры
        /// </summary>
        /// <param name="period">Время шага</param>
        public void Evolute(double period)
        {

            foreach (var item in _units)
            {
                item.Evolute(period);
            }
        }

        /// <summary>
        /// Проверяем на столкновения
        /// </summary>
        public void Collision()
        {
            for (var index = 0; index < _units.Count; index++)
            {
                for (var index2 = 0; index2 < _units.Count; index2++)
                {
                    var collision = _units[index].Collision(_units[index2], this);
                }
            }
        }

        /// <summary>
        /// Проверяет на окончание игры.
        /// В данном случае - все пузыри в статусе Passive.
        /// </summary>
        public void CheckStatus()
        { 
            var bubbleCount = _units.Count(u => u.GetType().Name == "Bubble");
            var passiveBubbleCount = _units.Count(u => u.GetType().Name == "Bubble" && u.UnitStatus == BubbleGame.Status.Passive);
            if (bubbleCount > 0 && bubbleCount == passiveBubbleCount)
            {
                Status = GameStatus.GameOver;
            }
        }

        /// <summary>
        /// Состояния игрового поля
        /// </summary>
        public enum GameStatus { Play, GameOver };
    }
}
