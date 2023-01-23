using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class MainMenuState : IPayloadedState<SceneName> {
        readonly GameStateMachine _stateMachine;
        readonly SceneLoader _sceneLoader;
        readonly LoadingScreen _loadingScreen;

        public MainMenuState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingScreen loadingScreen) {
            Debug.Log("MainMenuState constructor");
            
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
        }

        public void Enter(SceneName sceneName) {
            Debug.Log("MainMenuState enter");
            
            _loadingScreen.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() {
            Debug.Log("MainMenuState exit");
        }

        void OnLoaded() {
            _loadingScreen.Hide();
        }
        
        public class Factory : PlaceholderFactory<GameStateMachine, MainMenuState> {
        }
    }
}