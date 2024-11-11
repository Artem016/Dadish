using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private MainMenuReferencesSO _mainMenuReferences;

    public void PressAnyKeyZoneOnClick()
    {
        _mainMenuReferences.GetSceneManager().LoadTestLevel();
    }
}
