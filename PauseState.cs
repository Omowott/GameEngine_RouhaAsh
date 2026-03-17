using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class PauseState : IState
    {
        StateMachine _stateMachine;
        InGameState _gameState;
        public void Enter()
        {
            
        }

        public void Exit()
        {
            _stateMachine.ChangeState(_gameState);
        }

        public void ProcessInput(ConsoleKeyInfo input)
        {
            if(input.Key == ConsoleKey.Enter)
            {
                Exit();
            }
            if(input.Key == ConsoleKey.Q)
            {
                _stateMachine.ChangeState(new MainMenuState());
            }
        }

        public void Render()
        {

        }

        public void Update()
        {

        }
    }
}
