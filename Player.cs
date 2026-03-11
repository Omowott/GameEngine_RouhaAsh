using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Player : GameObject
    {
        private Vector2 _position = new Vector2();
        private string _renderGraphic = "@";
        private float _speed = 10.0f;
        private Vector2 _direction = new Vector2();
        private readonly Level _level;

        public Player(GameEngine game_engine, Level level) : base(game_engine)
        {
            _level = level;
        }


        public override void Render()
        {
            Console.SetCursorPosition((int)_position.GetX(),(int)_position.GetY());
            Console.Write(_renderGraphic);
        }

        public void SetPosition(Vector2 new_position)
        {
            _position = new_position;
            // limites --------------------------------------------------------------------------------------

            if (GetPosition().GetX() < 0) //limite X
            {
                GetPosition().SetX(0);
            }
            else if (GetPosition().GetX() >= Console.WindowWidth) //taille de fenetre
            {
                GetPosition().SetX(Console.WindowWidth - 1);
            }

            if (GetPosition().GetY() < 0) //même chose mais en Y
            {
                GetPosition().SetY(0);
            }
            else if (GetPosition().GetY() >= Console.WindowHeight)
            {
                GetPosition().SetY(Console.WindowHeight - 1);
            }
        }

        public void SetDirection(Vector2 new_direction)
        {
            _direction = new_direction;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public Vector2 GetDirection()
        {
            return _direction;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        //EXO 2 THRUST

        public override void Update(float elapsed_time)
        {
            
        }
        public override void FixedUpdate(float elapsed_time)
        {

        }

        public override void HandleInput(ConsoleKeyInfo player_command)
        {
            Vector2 new_direction = new Vector2(0, 0);

            if(player_command.Key == ConsoleKey.LeftArrow)
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
