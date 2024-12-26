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

    public void Save()
    {
        if (!File.Exists(savePath))
        {
            File.Create(savePath);
        }

        JsonSerializer serializer = new JsonSerializer();
        SaveData saveData = new SaveData();
        saveData.CompletedLevels = _savesSO.ComletedLevels;
        string json = JsonConvert.SerializeObject(saveData);
        File.WriteAllText(savePath, json);
    }

    public void Load()
    {
        if (!File.Exists(savePath))
        {
            File.Create(savePath);
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
        }
    }
}

public class SaveData
{
    public List<int> CompletedLevels;
}
