using System;
using Core.Services.ConfigProvider;
using Core.Services.InputService;
using Core.Services.SaveDataHandler;
using Core.Services.SaveLoadService;
using Core.Services.TimerProvider;
using Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Core.Installers {
    public sealed class GameInstaller : MonoInstaller {
        [SerializeField] CoroutineRunner CoroutineRunnerPrefab;
        [SerializeField] LoadingScreen LoadingScreenPrefab;

        public override void InstallBindings() {
            BindCoroutineRunner();
            BindLoadingScreen();
            BindSceneLoader();

            BindConfigProvider();

            BindSaveDataHandler();
            BindSaveLoadService();

            BindTimerProvider();
            BindTimerFactory();

            BindInputService();

            BindGameStateMachine();
        }

        void BindCoroutineRunner() {
            Container
                .BindInterfacesTo<CoroutineRunner>()
                .FromComponentInNewPrefab(CoroutineRunnerPrefab)
                .AsSingle();
        }

        void BindLoadingScreen() {
            Container
                .Bind<LoadingScreen>()
                .FromComponentInNewPrefab(LoadingScreenPrefab)
                .AsSingle();
        }

        void BindSceneLoader() {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        void BindConfigProvider() {
            Container
                .BindInterfacesAndSelfTo<ConfigProvider>()
                .AsSingle();
        }

        void BindSaveDataHandler() {
            Container
                .BindInterfacesAndSelfTo<SaveDataHandler>()
                .AsSingle();
        }

        void BindSaveLoadService() {
            Container
                .BindInterfacesAndSelfTo<JsonPrefsSaveLoadService>()
                .AsSingle();
        }

        void BindTimerProvider() {
            Container
                .BindInterfacesAndSelfTo<TimerProvider>()
                .AsSingle();
        }

        void BindTimerFactory() {
            Container
                .BindFactory<float, Action, Action<int>, bool, Timer, Timer.Factory>();
        }

        void BindInputService() {
            Container
                .BindInterfacesAndSelfTo<IInputService>()
                .FromMethod(CreateInputService);
        }

        IInputService CreateInputService(InjectContext context) {
            if ( Application.isEditor ) {
                return new StandaloneInputService();
            }
            else {
                return new MobileInputService();
            }
        }

        void BindGameStateMachine() {
            Container
                .Bind<GameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
        }
    }
}