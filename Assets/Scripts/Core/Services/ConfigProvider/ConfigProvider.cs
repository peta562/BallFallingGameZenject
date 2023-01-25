using Configs;
using UnityEngine;

namespace Core.Services.ConfigProvider {
    public sealed class ConfigProvider : IConfigProvider {
        const string LevelConfigPath = "Configs/LevelConfig";
        const string BallConfigPath = "Configs/BallConfig";
        
        LevelConfig _levelConfig;
        BallConfig _ballConfig;

        public void LoadConfigs() {
            _levelConfig = Resources.Load<LevelConfig>(LevelConfigPath);
            _ballConfig = Resources.Load<BallConfig>(BallConfigPath);
        }

        public BallConfig GetBallConfig() => _ballConfig;

        public LevelConfig GetLevelConfig() => _levelConfig;
    }
}