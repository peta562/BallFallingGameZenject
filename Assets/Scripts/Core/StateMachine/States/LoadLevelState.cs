using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class LoadLevelState : IPayloadedState<SceneName> {
        readonly GameStateMachine _stateMachine;
        readonly SceneLoader _sceneLoader;
        readonly LoadingScreen _loadingScreen;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingScreen loadingScreen) {
            Debug.Log("LoadLevelState constructor");
            
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
        }
        
        public void Enter(SceneName sceneName) {
            Debug.Log("LoadLevelState enter");
            
            _loadingScreen.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() {
            Debug.Log("LoadProgressState exit");
        }

        void OnLoaded() {
            _loadingScreen.Hide();
        }

        public class Factory : PlaceholderFactory<GameStateMachine, LoadLevelState> {
        }
    }
}