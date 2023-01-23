namespace Core.Services.SaveLoadService {
    public interface ISaveLoadService {
        void SaveData();
        SaveData.SaveData LoadData();
    }
}