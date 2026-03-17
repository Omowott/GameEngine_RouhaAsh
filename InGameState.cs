using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class InGameState : IState
    {
        StateMachine _stateMachine;
        PauseState _pausedState;

        public void Enter()
        {

        }

        public void Exit()
        {
            _stateMachine.ChangeState(_pausedState);
        }

        public void ProcessInput(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Escape)
            {
                Exit();
            }
        }

        public void Render()
        {
            Console.WriteLine("Escape to Pause");

        }

        public void Update()
        {
            Render();
        }
    }
}
