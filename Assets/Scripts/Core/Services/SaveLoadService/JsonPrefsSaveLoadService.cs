using Core.Services.SaveDataHandler;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Services.SaveLoadService {
    public sealed class JsonPrefsSaveLoadService : ISaveLoadService {
        readonly ISaveDataHandler _saveDataHandler;
        
        public JsonPrefsSaveLoadService(ISaveDataHandler saveDataHandler) {
            _saveDataHandler = saveDataHandler;
        }

        public void SaveData() {
            var json = JsonUtility.ToJson(_saveDataHandler.SaveData);

            PlayerPrefs.SetString("save_data", json);
        }

        [CanBeNull]
        public SaveData.SaveData LoadData() {
            var json = PlayerPrefs.GetString("save_data");
            
            if ( string.IsNullOrEmpty(json) ) {
                return null;
            }

            return JsonUtility.FromJson<SaveData.SaveData>(json);
        }
    }
}