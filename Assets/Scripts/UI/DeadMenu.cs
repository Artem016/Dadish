using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    [SerializeField] GameObject _background, _restartButton;
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
        _background.SetActive(true);
        _restartButton.SetActive(true);
    }

    public void RestartButton_OnClick()
    {
        //referencesSO.GetSceneManager().ReloadCurrentScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
