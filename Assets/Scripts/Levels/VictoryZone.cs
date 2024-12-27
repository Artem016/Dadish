using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour, IInteractable
{
    [SerializeField] SingletonReferencesSO referencesSO;
    [SerializeField] private int levelNumber;

    public void Interact(Player player)
    {
        referencesSO.GetSaveManager().AddComplatedLevel(levelNumber);
        referencesSO.GetSceneManager().LoadMainMenu();
    }

}
