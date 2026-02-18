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

        public void Run()
        {
            _stopwatch.Start();

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
            ConsoleKeyInfo player_command = Console.ReadKey(true);
            if(player_command.Key == ConsoleKey.Enter)
            {

            }
        }
        private void Update(float elapsed_time)
        {

        }
        private void Render()
        {

        }
        private float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
