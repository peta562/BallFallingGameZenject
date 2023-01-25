using System;
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
            _ballsController.Initialize();
        }

        public void Tick() {
           _ballsController.Tick();
        }

        public void Dispose() {
            
        }
    }
}