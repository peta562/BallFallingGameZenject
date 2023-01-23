using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class BootstrapState : IState {
        readonly GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine) {
            Debug.Log("BootstrapState constructor");
            
            _gameStateMachine = gameStateMachine;

        }

        public void Enter() {
            Debug.Log("BootstrapState Enter");

            _gameStateMachine.Enter<LoadConfigsState>();
        }

        public void Exit() {
            Debug.Log("BootstrapState Exit");
        }

        public class Factory : PlaceholderFactory<GameStateMachine, BootstrapState> {
        }
    }
}