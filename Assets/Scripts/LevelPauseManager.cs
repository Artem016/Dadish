using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelPauseManager : MonoBehaviour
{
    [SerializeField] InputAction _pauseAction;
    [SerializeField] GameObject _pauseMenu, _blackout;
    [SerializeField] SingletonReferencesSO _references;
    [SerializeField] Player _player;

    private void Awake()
    {
        _pauseAction.performed += OnPauseKeyPressed;
    }

    private void OnEnable()
    {
        _pauseAction.Enable();
    }

    private void OnDisable()
    {
        _pauseAction.Disable();
    }

    void OnPauseKeyPressed(InputAction.CallbackContext context)
    {
        _pauseMenu.SetActive(true);
        _blackout.SetActive(true);
        Pause();
    }

    public void OnContinue_Click()
    {
        _pauseMenu.SetActive(false);
        _blackout.SetActive(false);
        Unpause();
    }

    public void OnExit_Click()
    {
        Unpause();
        _references.GetSceneManager().LoadMainMenu();
    }

    void Pause()
    {
        _player.PauseMove();
        Time.timeScale = 0f;
    }

    void Unpause()
    {
        _player.UnpauseMove();
        Time.timeScale = 1f;
    }
}
