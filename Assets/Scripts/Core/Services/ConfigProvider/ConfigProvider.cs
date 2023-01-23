using Configs;
using UnityEngine;

namespace Core.Services.ConfigProvider {
    public sealed class ConfigProvider : IConfigProvider {
        const string LevelConfigPath = "Configs/LevelConfig";
        
        LevelConfig _levelConfig;

        public void LoadConfigs() {
            _levelConfig = Resources.Load<LevelConfig>(LevelConfigPath);
        }

        public LevelConfig GetLevelConfig() => _levelConfig;
    }
}