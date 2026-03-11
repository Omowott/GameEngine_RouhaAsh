using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Player : GameObject
    {
        private readonly string _renderGraphic = "@";

        private Vector2 _position = new Vector2(0, 0);
        private Vector2 _direction = new Vector2(0, 0);

        private readonly float _speed = 50;

        private readonly Level _level;

        public Player(GameEngine game_engine, Level level) : base(game_engine)
        {
            _level = level;
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            Vector2 new_position = new Vector2(
                _position.GetX() + _direction.GetX() * fixed_elapsed_time * _speed,
                _position.GetY() + _direction.GetY() * fixed_elapsed_time * _speed
            );

            if (new_position.GetX() < 0)
            {
                new_position.SetX(0);
            }
            else if (new_position.GetX() >= _level.GetWidth())
            {
                new_position.SetX(Console.WindowWidth - 1);
            }

            if (new_position.GetY() < 0)
            {
                new_position.SetY(0);
            }
            else if (new_position.GetY() >= _level.GetHeight())
            {
                new_position.SetY(Console.WindowHeight - 1);
            }

            _position = new_position;
            _direction = new Vector2(0, 0);
        }

        public override void Update(float elapsed_time)
        {

        }

        public override void Render()
        {
            Console.SetCursorPosition((int)_position.GetX(), (int)_position.GetY());
            Console.Write(_renderGraphic);
        }

        public override void HandleInput(ConsoleKeyInfo player_command)
        {
            Vector2 new_direction = new Vector2(0, 0);

            if (player_command.Key == ConsoleKey.LeftArrow)
            {
                new_direction = new Vector2(-1, 0);
            }

            else if (player_command.Key == ConsoleKey.RightArrow)
            {
                new_direction = new Vector2(1, 0);
            }

            else if (player_command.Key == ConsoleKey.UpArrow)
            {
                new_direction = new Vector2(0, -1);
            }

            else if (player_command.Key == ConsoleKey.DownArrow)
            {
                new_direction = new Vector2(0, 1);
            }

            _direction = new_direction;

        }
    }

}

