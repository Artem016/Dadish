using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] SelectedLevelDataSO _selectedLevelData;

    public void LoadLevel(int levelNumber)
    {
        _selectedLevelData.CurrentLevel = levelNumber;
        SceneManager.LoadScene("TestLevel");
    }
}
