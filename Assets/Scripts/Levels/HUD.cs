using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject _visual;
    [SerializeField] private SingletonReferencesSO _references;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneController.onLoadLevel += OnLoadLevel;
        SceneController.onLoadMainMenu += OnLoadMainMenu;
    }

    private void OnDestroy()
    {
        SceneController.onLoadLevel -= OnLoadLevel;
        SceneController.onLoadMainMenu -= OnLoadMainMenu;
    }

    public void CloseButtonClick()
    {
        _references.GetSceneManager().LoadMainMenu();
    }

    private void OnLoadLevel(int number)
    {
        _visual.SetActive(true);
    }

    private void OnLoadMainMenu()
    {
        Destroy(gameObject);
    }
}
