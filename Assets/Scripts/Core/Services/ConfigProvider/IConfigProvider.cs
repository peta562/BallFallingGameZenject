using Configs;

namespace Core.Services.ConfigProvider {
    public interface IConfigProvider {
        public LevelConfig GetLevelConfig();
        public BallConfig GetBallConfig();
        
        public void LoadConfigs();
    }
}