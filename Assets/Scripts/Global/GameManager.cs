using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SingletonReferencesSO _referencesSO;

    private void Awake()
    {
        _referencesSO.SetGameManager(this);
    }

    private void Start()
    {
        Player.onPlayerDies += OnPlayerDies;
    }

    private void OnDestroy()
    {
        Player.onPlayerDies -= OnPlayerDies;
    }

    public void GameOver()
    {
        _referencesSO.GetSceneManager().LoadMainMenu();
    }

    private void OnPlayerDies()
    {
        GameOver();
    }
}
