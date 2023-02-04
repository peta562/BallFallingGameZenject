using System;
using Core.Services.InputService;
using Game.Level.Balls;
using Game.UI.Level;
using UnityEngine;
using Zenject;

namespace Game.Level {
    public sealed class LevelManager : IInitializable, ITickable, IDisposable {
        readonly IInputService _inputService;
        readonly BallsController _ballsController;
        readonly HUD _hud;
        
        public LevelManager(IInputService inputService, BallsController ballsController, HUD hud) {
            _inputService = inputService;
            _ballsController = ballsController;
            _hud = hud;
        }
        
        public void Initialize() {
            _ballsController.Initialize(OnBallOutOfBorders);
        }

        public void Tick() {
            if ( _inputService.GetInputClick() ) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null) {
                    if ( hit.collider.TryGetComponent<Ball>(out var ball) ) {
                        _ballsController.HandleClick(ball);
                    }
                }    
            }
            
            _ballsController.Tick();
        }

        void OnBallOutOfBorders() {
        }

        public void Dispose() {
            _ballsController.Dispose();
        }
    }
}