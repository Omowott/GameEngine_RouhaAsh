using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Generator : GameObject
    {
        private readonly string _renderGraphic = "G";

        private Vector2 _position = new Vector2(0, 0);

        private float _elapsedTime;
        private int _resourceCount;
        private readonly float _productionRate;

        public Generator(float production_rate, GameEngine game_engine) : base(game_engine)
        {
            _productionRate = production_rate;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public override void Update(float elapsed_time)
        {

        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            _elapsedTime += fixed_elapsed_time;

            if (_elapsedTime >= _productionRate)
            {
                _resourceCount++;
                _elapsedTime = 0;
            }
        }

        public override void Render()
        {
            Console.SetCursorPosition((int)_position.GetX(), (int)_position.GetY());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{_renderGraphic}[{_resourceCount}]");
            Console.ResetColor();
        }

        public override void HandleInput(ConsoleKeyInfo player_command)
        {

        }
    }

}

