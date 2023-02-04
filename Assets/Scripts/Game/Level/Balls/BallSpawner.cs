using Core.Services.LevelSettingsProvider;
using UnityEngine;

namespace Game.Level.Balls {
    public sealed class BallSpawner {
        readonly Ball.Factory _ballFactory;
        readonly BallSettings _ballSettings;

        public BallSpawner(Ball.Factory ballFactory, ILevelSettingsProvider levelSettingsProvider) {
            _ballFactory = ballFactory;

            _ballSettings = levelSettingsProvider.LevelSettings.BallSettings;
        }

        public Ball Spawn(Vector2 screenBorders) {
            var ballScale = _ballSettings.Scale;
            var spawnPosition = CalculateSpawnPosition(screenBorders, ballScale);

            var ball = _ballFactory.Create(_ballSettings.Health, spawnPosition, ballScale,
                _ballSettings.Sprite, Color.red);
            ball.SetView();

            return ball;
        }

        Vector2 CalculateSpawnPosition(Vector2 screenBorders, float ballScale) {
            var randomPositionX = Random.Range(-screenBorders.x + ballScale / 2, screenBorders.x - ballScale / 2);
            var positionY = screenBorders.y + ballScale;

            return new Vector2(randomPositionX, positionY);
        }
    }
}