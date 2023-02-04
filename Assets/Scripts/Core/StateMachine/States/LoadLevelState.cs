using Core.Services.ProgressController;
using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class LoadLevelState : IPayloadedState<SceneName> {
        readonly GameStateMachine _stateMachine;
        readonly SceneLoader _sceneLoader;
        readonly LoadingScreen _loadingScreen;
        readonly IProgressController _progressController;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingScreen loadingScreen,
            IProgressController progressController) {
            Debug.Log("LoadLevelState constructor");

            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
            _progressController = progressController;
        }

        public void Enter(SceneName sceneName) {
            Debug.Log("LoadLevelState enter");
            
            _loadingScreen.Show();
            _progressController.StartNextLevel();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() {
            Debug.Log("LoadProgressState exit");
        }

        void OnLoaded() {
            _loadingScreen.Hide();
            _stateMachine.Enter<LevelLoopState>();
        }

        public class Factory : PlaceholderFactory<GameStateMachine, LoadLevelState> {
        }
    }
}