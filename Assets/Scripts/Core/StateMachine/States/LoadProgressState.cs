using Core.Services.SaveDataHandler;
using Core.Services.SaveLoadService;
using UnityEngine;
using Zenject;

namespace Core.StateMachine.States {
    public sealed class LoadProgressState : IState {
        readonly GameStateMachine _stateMachine;
        readonly ISaveDataHandler _saveDataHandler;
        readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine stateMachine, ISaveDataHandler saveDataHandler,
            ISaveLoadService saveLoadService) {
            Debug.Log("LoadProgressState constructor");

            _stateMachine = stateMachine;
            _saveDataHandler = saveDataHandler;
            _saveLoadService = saveLoadService;
        }

        public void Enter() {
            Debug.Log("LoadProgressState enter");

            LoadDataOrCreateNew();
            _stateMachine.Enter<MainMenuState, SceneName>(SceneName.MainMenu);
        }

        public void Exit() {
            Debug.Log("LoadProgressState exit");
        }

        void LoadDataOrCreateNew() {
            _saveDataHandler.SaveData = _saveLoadService.LoadData() ?? CreateData();
            Debug.Log(_saveDataHandler.SaveData);
        }

        SaveData.SaveData CreateData() {
            var saveData = new SaveData.SaveData();
            
            // set default data

            return saveData;
        }

        public class Factory : PlaceholderFactory<GameStateMachine, LoadProgressState> {
        }
    }
}