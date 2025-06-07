using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    [SerializeField] PanelController _panelController;
    [SerializeField] SingletonReferencesSO referencesSO;

    void Start()
    {
        Player.onPlayerDies += ShowDeadMenu;
    }

    private void OnDestroy()
    {
        Player.onPlayerDies -= ShowDeadMenu;
    }

    public void ShowDeadMenu()
    {
        _panelController.OpenRestartPanel();
    }

    public void RestartButton_OnClick()
    {
        //referencesSO.GetSceneManager().ReloadCurrentScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
