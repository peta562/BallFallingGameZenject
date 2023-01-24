using Core;
using Core.StateMachine;
using Core.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Game.UI.MainMenu {
    public sealed class MainMenuUI : MonoBehaviour {
        [SerializeField] UIButton PlayButton;
        
        GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine) {
            _gameStateMachine = gameStateMachine;
        }

        public void Init() {
            PlayButton.AddListener(OnPlayButtonClicked);
        }

        public void DeInit() {
            PlayButton.RemoveListener();
        }

        void OnPlayButtonClicked() {
            _gameStateMachine.Enter<LoadLevelState, SceneName>(SceneName.Level);
        }
    }
}