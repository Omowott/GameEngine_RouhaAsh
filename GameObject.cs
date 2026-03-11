using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    public abstract class GameObject
    {
        public GameObject(GameEngine game_engine)
        {
            game_engine.AddGameObject(this);
        }

        public abstract void Update(float elapsed_time);
        public abstract void FixedUpdate(float fixed_elapsed_time);

        public abstract void Render();
        public abstract void HandleInput(ConsoleKeyInfo player_command);
    }

}
