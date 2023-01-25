using System.Collections.Generic;
using Configs;
using Core.Services.ConfigProvider;
using Core.Services.TimerProvider;
using UnityEngine;

namespace Game.Level {
    public sealed class BallsController {
        readonly BallsSpawner _ballsSpawner;
        readonly ITimerProvider _timerProvider;
        readonly ScreenBordersProvider _screenBordersProvider;
        readonly LevelConfig _levelConfig;

        List<Ball> _balls;
        Vector2 _screenBorders;

        public BallsController(BallsSpawner ballsSpawner, ITimerProvider timerProvider,
            ScreenBordersProvider screenBordersProvider, IConfigProvider configProvider) {
            _ballsSpawner = ballsSpawner;
            _timerProvider = timerProvider;
            _screenBordersProvider = screenBordersProvider;

            _levelConfig = configProvider.GetLevelConfig();
        }

        public void Initialize() {
            _balls = new List<Ball>();

            _screenBorders = _screenBordersProvider.GetScreenBorders();

            _timerProvider.CreateTimer("BallSpawnTimer", _levelConfig.SpawnBallTime, OnBallSpawnTimerEnd, null, true);
            _timerProvider.StartTimer("BallSpawnTimer");
        }

        public void Tick() {
            for (var i = 0; i < _balls.Count; i++) {
                _balls[i].Tick();
                if ( _balls[i].CheckBallOutOfBorders(_screenBorders)) {
                    RemoveBall(_balls[i]);
                }
            }
        }

        void OnBallSpawnTimerEnd() {
            var ball = _ballsSpawner.SpawnBall(_screenBorders);
            _balls.Add(ball);
        }

        void RemoveBall(Ball ball) {
            ball.Destroy();
            _balls.Remove(ball);
        }

        public void Dispose() {
            _timerProvider.StopTimer("BallSpawnTimer");
            _timerProvider.RemoveTimer("BallSpawnTimer");
        }
    }
}