using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private SingletonReferencesSO _mainMenuReferences;
    public void StartButtonClick()
    {
        _mainMenuReferences.GetSceneManager().LoadLevel(1);
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
