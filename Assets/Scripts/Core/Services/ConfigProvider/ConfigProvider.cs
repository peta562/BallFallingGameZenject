using Configs;
using UnityEngine;

namespace Core.Services.ConfigProvider {
    public sealed class ConfigProvider : IConfigProvider {
        const string LevelsConfigPath = "Configs/LevelsConfig";

        LevelsConfig _levelsConfig;

        public void LoadConfigs() {
            _levelsConfig = Resources.Load<LevelsConfig>(LevelsConfigPath);
        }

        public LevelsConfig GetLevelsConfig() => _levelsConfig;
    }
}