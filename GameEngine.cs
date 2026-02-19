using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class GameEngine
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool _shouldQuit;

        private Player _player = new Player();

        public void Run()
        {
            _stopwatch.Start(); //start

            const float FIXED_FRAME_TIME = 20 / 1000.0f;
            float lag = 0.0f;
            float last_time = GetCurrentTime();
           
            while (!_shouldQuit)
            {
                float loop_start_time = GetCurrentTime();
                float elapsed_time = loop_start_time - last_time;
                lag += elapsed_time;
                ProcessInput();

                while (lag >= FIXED_FRAME_TIME)
                {
                    Update(FIXED_FRAME_TIME);
                    lag -= FIXED_FRAME_TIME;
                }

                Render();

                last_time = loop_start_time;
            }

            
        }
        //------------------------------------------------

        private void ProcessInput()
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo player_command = Console.ReadKey(true);

                if (player_command.Key == ConsoleKey.LeftArrow)
                {
                    _player.SetDirection(new Vector2(-1, 0));
                }
                else if (player_command.Key == ConsoleKey.RightArrow)
                {
                    _player.SetDirection(new Vector2(1, 0));
                }
                else if (player_command.Key == ConsoleKey.UpArrow)
                {
                    _player.SetDirection(new Vector2(0, -1));
                }
                else if (player_command.Key == ConsoleKey.DownArrow)
                {
                    _player.SetDirection(new Vector2(0, 1));
                }
            }
            
        }
        private void Update(float elapsed_time)
        {

        }
        private void Render()
        {
            _player.Render();
        }

        private float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
