using Configs;
using Core.Services.ConfigProvider;
using Core.Services.LevelSettingsProvider;
using Core.Services.SaveDataHandler;

namespace Core.Services.ProgressController {
    public sealed class ProgressController : IProgressController {
        readonly ISaveDataHandler _saveDataHandler;
        readonly ILevelSettingsProvider _levelSettingsProvider;
        readonly IConfigProvider _configProvider;

        public ProgressController(ISaveDataHandler saveDataHandler, ILevelSettingsProvider levelSettingsProvider,
            IConfigProvider configProvider) {
            _saveDataHandler = saveDataHandler;
            _levelSettingsProvider = levelSettingsProvider;

            _configProvider = configProvider;
        }

        public bool CanStartNextLevel() {
            var levelsConfig = _configProvider.GetLevelsConfig();
            var currentLevelId = _saveDataHandler.SaveData.CurrentLevelId;

            return currentLevelId <= levelsConfig.MaxLevelId;
        }

        public void StartNextLevel() {
            var levelsConfig = _configProvider.GetLevelsConfig();
            var currentLevelId = _saveDataHandler.SaveData.CurrentLevelId;

            var levelConfig = levelsConfig.GetLevelConfigForId(currentLevelId);
            _levelSettingsProvider.SetupLevelSettings(levelConfig);
        }
    }
}