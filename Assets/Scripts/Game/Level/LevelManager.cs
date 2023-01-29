using System;
using Game.Level.Balls;
using Game.UI.Level;
using Zenject;

namespace Game.Level {
    public sealed class LevelManager : IInitializable, ITickable, IDisposable {
        readonly BallsController _ballsController;
        readonly HUD _hud;
        
        public LevelManager(BallsController ballsController, HUD hud) {
            _ballsController = ballsController;
            _hud = hud;
        }
        
        public void Initialize() {
            _ballsController.Initialize(OnBallOutOfBorders);
        }

        public void Tick() {
           _ballsController.Tick();
        }

        void OnBallOutOfBorders(Ball ball) {
            _ballsController.RemoveBall(ball);
        }

        public void Dispose() {
            _ballsController.Dispose();
        }
    }
}