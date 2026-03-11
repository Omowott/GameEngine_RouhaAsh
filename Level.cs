using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Level : GameObject
    {
        private int _width = Console.WindowWidth;
        private int _height = Console.WindowHeight;

        private readonly Random _random = new Random();

        private float _timeSinceLastEnemyGeneration = 0;
        private float _timeToNextEnemyGeneration = 1.0f;

        private readonly int _maxEnemyCount = 10;

        private readonly GameEngine _gameEngine;
        private int _currentEnemyCount;

        public Level(GameEngine game_engine) : base(game_engine)
        {
            _gameEngine = game_engine;

            Building building = new Building(_gameEngine);
            building.SetPosition(new Vector2(10, 10));

            Generator generator = new Generator(10, _gameEngine);
            generator.SetPosition(new Vector2(15, 15));

            Factory factory = new Factory(10, 2, 1, _gameEngine);
            factory.SetPosition(new Vector2(50, 8));
        }

        public override void Update(float elapsed_time)
        {

        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            if (_currentEnemyCount < _maxEnemyCount)
            {
                _timeSinceLastEnemyGeneration += fixed_elapsed_time;

                if (_timeSinceLastEnemyGeneration >= _timeToNextEnemyGeneration)
                {
                    _timeSinceLastEnemyGeneration = 0;
                    Enemy enemy = new Enemy(_gameEngine, this);
                    enemy.SetPosition(new Vector2(_random.Next(0, _width), _random.Next(0, _height)));
                    _timeToNextEnemyGeneration = _random.Next(5, 11);
                    _currentEnemyCount++;
                }
            }
        }

        public override void Render()
        {

        }

        public override void HandleInput(ConsoleKeyInfo player_command)
        {

        }

        public float GetWidth()
        {
            return _width;
        }

        public float GetHeight()
        {
            return _height;
        }
    }

}

