using System;
using System.Collections.Generic;
using Core.Services.LevelSettingsProvider;
using Core.Services.TimerProvider;
using UnityEngine;

namespace Game.Level.Balls {
    public sealed class BallsController {
        readonly BallSpawner _ballSpawner;
        readonly ITimerProvider _timerProvider;
        readonly ScreenBordersProvider _screenBordersProvider;
        readonly BallSettings _ballSettings;
        readonly CommonSettings _commonSettings;

        List<Ball> _activeBalls;
        Vector2 _screenBorders;
        
        Action _onBallOutOfBorders;

        public BallsController( BallSpawner ballSpawner, ITimerProvider timerProvider,
            ScreenBordersProvider screenBordersProvider, ILevelSettingsProvider levelSettingsProvider) {
            _ballSpawner = ballSpawner;
            _timerProvider = timerProvider;
            _screenBordersProvider = screenBordersProvider;

            _ballSettings = levelSettingsProvider.LevelSettings.BallSettings;
            _commonSettings = levelSettingsProvider.LevelSettings.CommonSettings;
        }

        public void Initialize(Action onBallOutOfBorders) {
            _onBallOutOfBorders = onBallOutOfBorders;

            _activeBalls = new List<Ball>();

            _screenBorders = _screenBordersProvider.GetScreenBorders();

            _timerProvider.CreateTimer("BallSpawnTimer", _ballSettings.SpawnTime, OnBallSpawnTimerEnd, null, true);
            _timerProvider.StartTimer("BallSpawnTimer");
        }

        public void Tick() {
            for (var i = 0; i < _activeBalls.Count; i++) {
                _activeBalls[i].Move(Vector2.down, _ballSettings.Speed);
                
                if ( _activeBalls[i].CheckOutOfBorders(_screenBorders)) {
                    _onBallOutOfBorders?.Invoke();
                    RemoveBall(_activeBalls[i]);
                }
            }
        }

        public void RemoveBall(Ball ball) {
            ball.Dispose();
            _activeBalls.Remove(ball);
        }

        public void HandleClick(Ball ball) {
            ball.TakeDamage(_commonSettings.Damage);
            ball.PlayHitEffect();
            if ( ball.Health <= 0 ) {
                KillBall(ball);
            }
        }

        void KillBall(Ball ball) {
            ball.PlayDieEffect();
            RemoveBall(ball);
        }

        void OnBallSpawnTimerEnd() {
            var ball = _ballSpawner.Spawn(_screenBorders);
            _activeBalls.Add(ball);
        }

        public void Dispose() {
            _timerProvider.StopTimer("BallSpawnTimer");
            _timerProvider.RemoveTimer("BallSpawnTimer");
        }
    }
}