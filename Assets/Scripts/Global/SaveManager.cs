using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static Action OnLoadSave;
    public static Action OnLoadEmptySave;
    public static Action OnSaveChange;

    [SerializeField] private SingletonReferencesSO _referencesSO;
    [SerializeField] private SavesSO _savesSO;


    private static string savePath;

    private void Awake()
    {
        _referencesSO.SetSaveManager(this);
        savePath = Application.persistentDataPath + "/save.json";
        if (!File.Exists(savePath))
        {
            File.Create(savePath);
        }
    }

    private void Start()
    {
        
        Load();
    }

    public void AddComplatedLevel(int numberLevel)
    {
        if (!_savesSO.ComletedLevels.Contains(numberLevel))
        {
            //Debug.LogError(0);
            _savesSO.ComletedLevels.Add(numberLevel);
            OnSaveChange?.Invoke();
            Save();
        }
    }

    public void Save()
    {
        if (!File.Exists(savePath))
        {
            File.Create(savePath);
            Debug.Log("Save file not exists. Create new file.");
        }

        JsonSerializer serializer = new JsonSerializer();
        SaveData saveData = new SaveData();
        saveData.CompletedLevels = _savesSO.ComletedLevels;
        string json = JsonConvert.SerializeObject(saveData);
        File.WriteAllText(savePath, json);
        Debug.Log("Save progress.");
    }

    public void Load()
    {
        if (!File.Exists(savePath))
        {
            File.Create(savePath);
            Debug.Log("Save file not exists. Create new file.");
        }
        using (StreamReader sr = new StreamReader(savePath))
        {
            string json = sr.ReadToEnd();
            var deserializeSave = JsonConvert.DeserializeObject<SaveData>(json);

            if (deserializeSave == null)
            {
                _savesSO.ComletedLevels = new List<int>();
            }
            else
            {
                _savesSO.ComletedLevels = deserializeSave.CompletedLevels;
            }

            if(_savesSO.ComletedLevels.Count <= 0)
            {
                OnLoadEmptySave?.Invoke();
            }
            else
            {
                OnLoadSave?.Invoke();
            }
            Debug.Log("Load progress");
        }
    }
}

public class SaveData
{
    public List<int> CompletedLevels;
}
