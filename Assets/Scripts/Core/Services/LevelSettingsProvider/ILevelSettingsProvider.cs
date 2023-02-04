using Configs;

namespace Core.Services.LevelSettingsProvider {
    public interface ILevelSettingsProvider {
        public LevelSettings LevelSettings { get; }
        
        void SetupLevelSettings(LevelConfig levelConfig);
    }
}