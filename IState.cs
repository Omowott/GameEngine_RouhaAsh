using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal interface IState
    {
        void Enter();
        void Exit();
        void Update();
        void ProcessInput(ConsoleKeyInfo input);
        void Render();
    }
}
