using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour, IInteractable
{
    public static Action<string, int> onVictoryZoneInteract;

    [SerializeField] string _dialogName;
    [SerializeField] SingletonReferencesSO _referencesSO;
    [SerializeField] int _levelNumber;

    public void Interact(Player player)
    {
        player.StopMove();
        onVictoryZoneInteract?.Invoke(_dialogName, _levelNumber);
        //referencesSO.GetSaveManager().AddComplatedLevel(levelNumber);
        //referencesSO.GetSceneManager().LoadMainMenu();
    }

}
