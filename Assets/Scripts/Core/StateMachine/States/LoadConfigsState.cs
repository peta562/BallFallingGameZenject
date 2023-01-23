using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class LoadConfigsState : IState {
        readonly GameStateMachine _stateMachine;

        public LoadConfigsState(GameStateMachine stateMachine) {
            Debug.Log("LoadConfigsState constructor");
            
            _stateMachine = stateMachine;
        }
        
        public void Enter() {
            Debug.Log("LoadConfigsState enter");

            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit() {
            Debug.Log("LoadConfigsState exit");
        }
        
        public class Factory : PlaceholderFactory<GameStateMachine, LoadConfigsState> {
        }
    }
}