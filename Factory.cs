using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine_RouhaAsh
{
    internal class Factory : GameObject
    {
            private readonly string _renderGraphic = "F";

            private Vector2 _position = new Vector2(0, 0);

            private float _elapsedConsumptionTime;
            private float _elapsedProductionTime;

            private int _inputCount;

            private readonly float _consumptionRate;
            private readonly float _productionRate;

            private int _resourceCount;

            public Factory(int input_count, int consumption_rate, int production_rate, GameEngine game_engine) : base(game_engine)
            {
                _inputCount = input_count;
                _consumptionRate = consumption_rate;
                _productionRate = production_rate;
            }

            public void SetPosition(Vector2 position)
            {
                _position = position;
            }

            public override void Update(float elapsed_time)
            {

            }

            public override void FixedUpdate(float fixed_elapsed_time)
            {
                if (_inputCount > 0)
                {
                    _elapsedConsumptionTime += fixed_elapsed_time;

                    if (_elapsedConsumptionTime >= _consumptionRate)
                    {
                        _inputCount--;
                        _elapsedConsumptionTime = 0;
                    }

                    _elapsedProductionTime += fixed_elapsed_time;

                    if (_elapsedProductionTime >= _productionRate)
                    {
                        _resourceCount++;
                        _elapsedProductionTime = 0;
                    }
                }
            }

            public override void Render()
            {
                Console.SetCursorPosition((int)_position.GetX(), (int)_position.GetY());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{_renderGraphic}[{_inputCount}->{_resourceCount}]");
                Console.ResetColor();
            }

            public override void HandleInput(ConsoleKeyInfo player_command)
            {

            }

    }
}
