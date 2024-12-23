using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, IInterScene
{
    private string _currentScene = "MainMenu";
    private readonly string _testLevelScene = "TestLevel";
    private readonly string _firstLevel = "Level1";

    [SerializeField] private SingletonReferencesSO _referencesSO;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _referencesSO.SetSceneManager(this);
    }

    public void LoadTestLevel()
    {
        SceneManager.LoadScene(_testLevelScene);
        _currentScene = _testLevelScene;
    }

    public void LoadLevel(int number)
    {
        switch (number)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            default:
                break;
        }
    }

    public void LoadLevel(SaveData saveData)
    {
        switch (saveData.currentLevelIndex)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            default:
                break;
        }
    }

    public void ReloadCurrentScene()
    {
        if (_currentScene != null)
        {
            SceneManager.LoadScene(_currentScene);
        }
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
