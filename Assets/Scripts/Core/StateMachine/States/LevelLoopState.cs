using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class LevelLoopState : IState {
        readonly GameStateMachine _stateMachine;

        public LevelLoopState(GameStateMachine stateMachine) {
            Debug.Log("LevelLoopState constructor");
            
            _stateMachine = stateMachine;
        }
        
        public void Enter() {
            Debug.Log("LevelLoopState enter");
        }

        public void Exit() {
            Debug.Log("LevelLoopState exit");
        }

        public class Factory : PlaceholderFactory<GameStateMachine, LevelLoopState> {
        }
    }
}