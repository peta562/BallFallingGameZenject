using System;
using System.Collections.Generic;
using Configs;
using Core.Services.ConfigProvider;
using Core.Services.TimerProvider;
using UnityEngine;

namespace Game.Level.Balls {
    public sealed class BallsController {
        readonly BallSpawner _ballSpawner;
        readonly ITimerProvider _timerProvider;
        readonly ScreenBordersProvider _screenBordersProvider;
        readonly LevelConfig _levelConfig;

        List<Ball> _activeBalls;
        Vector2 _screenBorders;
        
        Action<Ball> _onBallOutOfBorders;

        public BallsController(BallSpawner ballSpawner, ITimerProvider timerProvider,
            ScreenBordersProvider screenBordersProvider, IConfigProvider configProvider) {
            _ballSpawner = ballSpawner;
            _timerProvider = timerProvider;
            _screenBordersProvider = screenBordersProvider;

            _levelConfig = configProvider.GetLevelConfig();
        }

        public void Initialize(Action<Ball> onBallOutOfBorders) {
            _onBallOutOfBorders = onBallOutOfBorders;
            
            _activeBalls = new List<Ball>();

            _screenBorders = _screenBordersProvider.GetScreenBorders();

            _timerProvider.CreateTimer("BallSpawnTimer", _levelConfig.SpawnBallTime, OnBallSpawnTimerEnd, null, true);
            _timerProvider.StartTimer("BallSpawnTimer");
        }

        public void Tick() {
            for (var i = 0; i < _activeBalls.Count; i++) {
                _activeBalls[i].Move(Vector2.down, _levelConfig.BallsSpeed);
                
                if ( _activeBalls[i].CheckOutOfBorders(_screenBorders)) {
                    _onBallOutOfBorders?.Invoke(_activeBalls[i]);
                }
            }
        }

        public void RemoveBall(Ball ball) {
            ball.Dispose();
            _activeBalls.Remove(ball);
        }

        void OnBallSpawnTimerEnd() {
            var ball = _ballSpawner.Create(_screenBorders);
            _activeBalls.Add(ball);
        }

        public void Dispose() {
            _timerProvider.StopTimer("BallSpawnTimer");
            _timerProvider.RemoveTimer("BallSpawnTimer");
        }
    }
}