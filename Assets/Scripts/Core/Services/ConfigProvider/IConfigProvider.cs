using Configs;

namespace Core.Services.ConfigProvider {
    public interface IConfigProvider {
        public LevelsConfig GetLevelsConfig();

        public void LoadConfigs();
    }
}