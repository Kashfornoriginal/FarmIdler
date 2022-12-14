using Data.Dynamic.PlayerData;
using Data.Extensions;
using Services.PersistentProgress;
using Services.Watchers.SaveLoadWatcher;
using UnityEngine;

namespace Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        public SaveLoadService(IPersistentProgressService persistentProgressService, 
            ISaveLoadInstancesWatcher saveLoadInstancesWatcher)
        {
            _persistentProgressService = persistentProgressService;
            _saveLoadInstancesWatcher = saveLoadInstancesWatcher;
        }

        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadInstancesWatcher _saveLoadInstancesWatcher;
        
        private const string SaveLoadKey = "SaveLoadKey";
        
        public void SaveProgress()
        {
            foreach (var progressSavable in _saveLoadInstancesWatcher.ProgressSavable)
            {
                progressSavable.UpdateProgress(_persistentProgressService.PlayerProgress);
            }
            
            PlayerPrefs.SetString(SaveLoadKey, _persistentProgressService.PlayerProgress.ToJson());
        }
        
        public PlayerProgress LoadProgress()
        {
            if (!PlayerPrefs.HasKey(SaveLoadKey))
            {
                return null;
            }
            
            var prefs = PlayerPrefs.GetString(SaveLoadKey)?.FromJson<PlayerProgress>();
            return prefs;   
        }
    }
}
