using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelPauseManager : MonoBehaviour
{
    [SerializeField] InputAction _pauseAction;
    [SerializeField] PanelController _panelController;
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
        _panelController.OpenPausePanel();
        Pause();
    }

    public void OnContinue_Click()
    {
        _panelController.CloseSelectPanel();
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
