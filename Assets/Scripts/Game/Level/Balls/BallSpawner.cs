using Configs;
using Core.Services.ConfigProvider;
using UnityEngine;

namespace Game.Level.Balls {
    public sealed class BallSpawner {
        readonly Ball.Factory _ballFactory;
        readonly BallConfig _ballConfig;

        public BallSpawner(Ball.Factory ballFactory, IConfigProvider configProvider) {
            _ballFactory = ballFactory;
            _ballConfig = configProvider.GetBallConfig();
        }

        public Ball Create(Vector2 screenBorders) {
            var ballScale = _ballConfig.Scale;
            var spawnPosition = CalculateSpawnPosition(screenBorders, ballScale);

            var ball = _ballFactory.Create(_ballConfig.Health, spawnPosition, ballScale,
                _ballConfig.Sprite, Color.red);
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