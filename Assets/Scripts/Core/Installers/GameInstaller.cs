using Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Core.Installers {
    public sealed class GameInstaller: MonoInstaller {
        [SerializeField] CoroutineRunner CoroutineRunnerPrefab;
        [SerializeField] LoadingScreen LoadingScreenPrefab;
        
        public override void InstallBindings() {
            BindCoroutineRunner();
            BindLoadingScreen();
            BindSceneLoader();

            BindGameStateMachine();
        }

        void BindCoroutineRunner() {
            Container
                .Bind<CoroutineRunner>()
                .FromComponentInNewPrefab(CoroutineRunnerPrefab)
                .AsSingle();
        }

        void BindLoadingScreen() {
            Container
                .Bind<LoadingScreen>()
                .FromComponentInNewPrefab(LoadingScreenPrefab)
                .AsSingle();
        }

        void BindGameStateMachine() {
            Container.Bind<GameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
        }

        void BindSceneLoader() {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }
    }
}