using Configs;

namespace Core.Services.ConfigProvider {
    public interface IConfigProvider {
        public LevelConfig GetLevelConfig();
        
        public void LoadConfigs();
    }
}