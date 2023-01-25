using Configs;
using Core.Services.ConfigProvider;
using UnityEngine;

namespace Game.Level {
    public sealed class BallsSpawner {
        readonly BallConfig _ballConfig;
        readonly Ball.Factory _ballFactory;

        public BallsSpawner(IConfigProvider configProvider, Ball.Factory ballFactory) {
            _ballConfig = configProvider.GetBallConfig();
            _ballFactory = ballFactory;
        }

        public Ball SpawnBall(Vector2 screenBorders) {
            var ballScale = _ballConfig.Scale;
            var spawnPosition = CalculateSpawnPosition(screenBorders, ballScale);

            return _ballFactory.Create(_ballConfig.Speed, spawnPosition);
        }

        Vector2 CalculateSpawnPosition(Vector2 screenBorders, float ballScale) {
            var randomPositionX = Random.Range(-screenBorders.x + ballScale / 2, screenBorders.x - ballScale / 2);
            var positionY = screenBorders.y + ballScale;

            return new Vector2(randomPositionX, positionY);
        }
    }
}