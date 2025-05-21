using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static Action<int> onLoadLevel;
    public static Action onLoadMainMenu;

    //перенести в so 
    private static string _currentScene = _mainMenuSceneName;
    private static readonly string _mainMenuSceneName = "MainMenu";
    [SerializeField] private List<string> _levels;

    [SerializeField] private SingletonReferencesSO _referencesSO;
    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _referencesSO.SetSceneManager(this);
        LoadMainMenu();
    }

    public void LoadLevel(int number)
    {
        if(number <= _levels.Count)
        {
            onLoadLevel?.Invoke(number);
            SceneManager.LoadScene(_levels[number]);
        }
        else
        {
            Debug.LogError("this number of level is not found");
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
        onLoadMainMenu?.Invoke();
        SceneManager.LoadScene(_mainMenuSceneName);
    }
}
