using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainMenuReferences", menuName = "MainMenuRefereces")]
public class MainMenuReferencesSO : ScriptableObject
{
    private SceneController _sceneManager;

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
    
    private GameManager _gameManager;

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
}
