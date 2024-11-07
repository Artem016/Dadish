using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private MainMenuReferencesSO _mainMenuReferences;
    public void PlayButtonOnClick()
    {
        _mainMenuReferences.GetSceneManager().LoadTestLevel();
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
