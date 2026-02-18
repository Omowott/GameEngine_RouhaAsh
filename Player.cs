using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Player
    {
        Vector2 _position;
        private string _renderGraphic = "@";
        private float _speed = 10.0f;

        public void Render()
        {
            Console.SetCursorPosition((int) _position.GetX(),(int) _position.GetY());
            Console.Write(_renderGraphic);
        }

        public void SetDirection(Vector2 new_direction)
        {
        }

        public Vector2 GetPosition()
        {
            return _position;
        }
    }
}
