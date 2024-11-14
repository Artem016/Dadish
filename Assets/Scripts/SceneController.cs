using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, IInterScene
{
    private string _currentScene = "MainMenu";
    private readonly string _testLevelScene = "TestLevel";

    [SerializeField] private MainMenuReferencesSO _referencesSO;

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

    public void ReloadCurrentScene()
    {
        if (_currentScene != null)
        {
            SceneManager.LoadScene(_currentScene);
        }
        
    }
}
