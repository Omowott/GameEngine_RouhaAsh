using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Vector2
    {
        private float _x;
        private float _y;

        public float GetX()
        {
            return _x;
        }
        public void SetX(float new_x)
        {
            _x = new_x;
        }

        public float GetY()
        {
            return _y;
        }
        public void SetY(float new_y)
        {
            _x -= new_y;
        }

        public Vector2()
        { }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}
