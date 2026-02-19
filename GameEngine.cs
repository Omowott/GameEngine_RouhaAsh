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
            Console.CursorVisible = false;

            const float FIXED_FRAME_TIME = 20 / 1000.0f;
            float lag = 0.0f;
            float last_time = GetCurrentTime();
           
            while (!_shouldQuit)
            {
                float loop_start_time = GetCurrentTime();
                float elapsed_time = loop_start_time - last_time;
                lag += elapsed_time;
                ProcessInput();
                Update(elapsed_time);

                while (lag >= FIXED_FRAME_TIME)
                {
                    FixedUpdate(FIXED_FRAME_TIME);
                    lag -= FIXED_FRAME_TIME;
                }

                Render();

                last_time = loop_start_time;
            }

            
        }

        public void FixedUpdate(float elapsed_time)
        {
            Vector2 player_position = _player.GetPosition();
            Vector2 player_direction = _player.GetDirection();

            Vector2 new_position = new Vector2(0, 0);

            new_position.SetX(player_position.GetX() + player_direction.GetX() * elapsed_time * _player.GetSpeed());
            new_position.SetY(player_position.GetY() + player_direction.GetY() * elapsed_time * _player.GetSpeed());

            _player.SetPosition(new_position);
            _player.SetDirection(new Vector2(0, 0));


        }

        //--------------------------------------------------------------------------------------------------------------------------------

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
            Console.Clear();
            _player.Render();
        }

        private float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
