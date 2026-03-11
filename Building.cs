using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Building : GameObject
    {
        private readonly string _renderGraphic = "B";

        private Vector2 _position = new Vector2(0, 0);

        private float _elapsedTime;

        public Building(GameEngine game_engine) : base(game_engine)
        {
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
        }

        public override void Render()
        {
            Console.SetCursorPosition((int)_position.GetX(), (int)_position.GetY());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{_renderGraphic}[{_elapsedTime:F1}]");
            Console.ResetColor();
        }

        public override void HandleInput(ConsoleKeyInfo player_command)
        {

        }

    }
}
