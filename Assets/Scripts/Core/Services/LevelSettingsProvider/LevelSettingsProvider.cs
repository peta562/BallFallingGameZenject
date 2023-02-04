using Configs;

namespace Core.Services.LevelSettingsProvider {
    public class LevelSettingsProvider : ILevelSettingsProvider {
        public LevelSettings LevelSettings { get; private set; }

        public void SetupLevelSettings(LevelConfig levelConfig) {
            LevelSettings = new LevelSettings();
            LevelSettings.Setup(levelConfig);
        }
    }
}