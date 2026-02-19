using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Player
    {
        private Vector2 _position = new Vector2();
        private string _renderGraphic = "@";
        private float _speed = 10.0f;
        private Vector2 _direction = new Vector2();

        public void Render()
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
    }
}
