using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class StateMachine
    {
        private IState _currentState;

        public void SetInitialState(IState initial_state)
        {
            _currentState = initial_state;
            _currentState.Enter();
        }
        public void ChangeState(IState new_state)
        {
            _currentState.Exit();
            _currentState = new_state;
            new_state.Enter();
        }
        public void ProcessInput(ConsoleKeyInfo input)
        {
            _currentState.ProcessInput(input);
        }
        public void Update()
        {
            _currentState.Update();
        }
        public void Render()
        {
            _currentState.Render();
        }
    }
}
