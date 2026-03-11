using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace GameEngine_RouhaAsh
{
    public class GameEngine
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool _shouldQuit;

        private readonly List<GameObject> _gameObjectTable = new List<GameObject>();
        private readonly List<GameObject> _gameObjectToAddTable = new List<GameObject>();
        private readonly List<GameObject> _gameObjectToRemoveTable = new List<GameObject>();

        public void AddGameObject(GameObject game_object)
        {
            _gameObjectToAddTable.Add(game_object);
        }

        public void RemoveGameObject(GameObject game_object)
        {
            _gameObjectToRemoveTable.Add(game_object);
        }


        public void Run()
        {
            _stopwatch.Start(); //start
            Console.CursorVisible = false;

            const float FIXED_FRAME_TIME = 20 / 1000.0f;
            float lag = 0.0f;
            float last_time = GetCurrentTime();

            Level level = new Level(this);
            Player player = new Player(this,level);

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

                UpdateGameObjectTable();

                Render();

                last_time = loop_start_time;
            }
            Console.WriteLine("Goodbye!");
        }

        public void FixedUpdate(float fixed_elapsed_time)
        {
            foreach (GameObject game_object in _gameObjectTable)
            {
                game_object.FixedUpdate(fixed_elapsed_time);
            }
        }


        private void UpdateGameObjectTable()
        {
            foreach (GameObject game_object in _gameObjectToRemoveTable)
            {
                _gameObjectTable.Remove(game_object);
            }

            _gameObjectToRemoveTable.Clear();

            foreach (GameObject game_object in _gameObjectToAddTable)
            {
                _gameObjectTable.Add(game_object);
            }

            _gameObjectToAddTable.Clear();
        }


        //--------------------------------------------------------------------------------------------------------------------------------

        private void ProcessInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo player_command = Console.ReadKey(true);

                if (player_command.Key == ConsoleKey.Escape)
                {
                    _shouldQuit = true;
                }
                else
                {
                    foreach (GameObject game_object in _gameObjectTable)
                    {
                        game_object.HandleInput(player_command);
                    }
                }
            }

        }
        private void Update(float elapsed_time)
        {
            foreach (GameObject game_object in _gameObjectTable)
            {
                game_object.Update(elapsed_time);
            }

        }
        private void Render()
        {
            Console.Clear();

            foreach (GameObject game_object in _gameObjectTable)
            {
                game_object.Render();
            }

            Thread.Sleep(10);

        }

        private float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
