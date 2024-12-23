using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SingletonReferences", menuName = "SingletonRefereces")]
public class SingletonReferencesSO : ScriptableObject
{
    private SceneController _sceneManager;
    private GameManager _gameManager;
    private SaveManager _saveManager;

    public void SetSceneManager(SceneController sceneManager)
    {
        _sceneManager = sceneManager;
    }

    public SceneController GetSceneManager()
    {
        if (_sceneManager == null)
        {
            Debug.LogError("scene manager is null. retuned null");
            return null;
        }

        return _sceneManager;
    }    
    


    public void SetGameManager(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public GameManager GetGameManager()
    {
        if (_gameManager == null)
        {
            Debug.LogError("game manager is null. retuned null");
            return null;
        }

        return _gameManager;
    }    
    
    public void SetSaveManager(SaveManager saveManager)
    {
        _saveManager = saveManager;
    }

    public SaveManager GetSaveManager()
    {
        if (_saveManager == null)
        {
            Debug.LogError("save manager is null. retuned null");
            return null;
        }

        return _saveManager;
    }
}
