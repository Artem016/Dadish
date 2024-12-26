using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private SingletonReferencesSO referencesSO;

    private static string savePath;

    private void Awake()
    {
        referencesSO.SetSaveManager(this);
    }

    private void Start()
    {
        savePath = Application.persistentDataPath + "/save.json";
        //var saveData = LoadGame();

        //if (saveData.currentLevelIndex > 0)
        //    referencesSO.GetSceneManager().LoadLevel(saveData.currentLevelIndex);
    }

    // Сохранение данных
    public static void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved to: " + savePath);
    }

    // Загрузка данных
    public static SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game Loaded from: " + savePath);
            return data;
        }
        else
        {
            Debug.Log("Save file not found, start new game");
            return null;
        }
    }
}

public class SaveData
{
    public string name;
    public int currentLevelIndex;
}
