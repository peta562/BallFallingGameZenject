using Core.StateMachine;
using Core.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core.Installers {
    public sealed class GameStateMachineInstaller : Installer<GameStateMachineInstaller> {
        public override void InstallBindings()
        {
            Container.BindFactory<GameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<GameStateMachine, LoadConfigsState, LoadConfigsState.Factory>();
            Container.BindFactory<GameStateMachine, LoadProgressState, LoadProgressState.Factory>();
            Container.BindFactory<GameStateMachine, MainMenuState, MainMenuState.Factory>();
            Container.BindFactory<GameStateMachine, LoadLevelState, LoadLevelState.Factory>();
            Container.BindFactory<GameStateMachine, LevelLoopState, LevelLoopState.Factory>();

            Container.Bind<GameStateMachine>().AsSingle();
        
            Debug.Log("GameStateMachineInstaller");
        }
    }
}