using Core.Services.ConfigProvider;
using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class LoadConfigsState : IState {
        readonly GameStateMachine _stateMachine;
        readonly IConfigProvider _configProvider;

        public LoadConfigsState(GameStateMachine stateMachine, IConfigProvider configProvider) {
            Debug.Log("LoadConfigsState constructor");
            
            _stateMachine = stateMachine;
            _configProvider = configProvider;
        }
        
        public void Enter() {
            Debug.Log("LoadConfigsState enter");

            LoadConfigs();
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit() {
            Debug.Log("LoadConfigsState exit");
        }

        void LoadConfigs() => 
            _configProvider.LoadConfigs();

        public class Factory : PlaceholderFactory<GameStateMachine, LoadConfigsState> {
        }
    }
}