using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class LoadProgressState : IState {
        readonly GameStateMachine _stateMachine;

        public LoadProgressState(GameStateMachine stateMachine) {
            Debug.Log("LoadProgressState constructor");
            
            _stateMachine = stateMachine;
        }
        
        public void Enter() {
            Debug.Log("LoadProgressState enter");

            _stateMachine.Enter<MainMenuState, SceneName>(SceneName.MainMenu);
        }

        public void Exit() {
            Debug.Log("LoadProgressState exit");
        }
        
        public class Factory : PlaceholderFactory<GameStateMachine, LoadProgressState> {
        }
    }
}