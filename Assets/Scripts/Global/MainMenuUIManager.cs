using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private SingletonReferencesSO _mainMenuReferences;
    public void LevelButtonClick(int numberLevel)
    {
        _mainMenuReferences.GetSceneManager().LoadLevel(numberLevel);
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
