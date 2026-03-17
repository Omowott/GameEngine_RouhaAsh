using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class MainMenuState : IState
    {
        GameEngine _gameEngine;
        StateMachine _stateMachine;
        InGameState _gameState;
        PauseState _pauseState;

        public void Enter()
        {
            
        }

        public void Exit()
        {
            _gameEngine.SetQuit(true);
        }

        public void ProcessInput(ConsoleKeyInfo input)
        {
            if(input.Key == ConsoleKey.Enter)
            {
                _stateMachine.ChangeState(new InGameState());
            }
            if(input.Key != ConsoleKey.Escape)
            {
                Exit();
            }
        }

        public void Render()
        {
            Console.WriteLine("Titre");
        }

        public void Update()
        {
            Render();
        }
    }
}
