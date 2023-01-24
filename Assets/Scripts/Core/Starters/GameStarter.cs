using Core.StateMachine;
using Core.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core.Starters {
    public sealed class GameStarter : MonoBehaviour {
        GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine) {
            _gameStateMachine = gameStateMachine;
        }
        
        void Start() {
            _gameStateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}