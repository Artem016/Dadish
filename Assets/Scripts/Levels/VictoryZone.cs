using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour, IInteractable
{
    [SerializeField] SingletonReferencesSO referencesSO;

    public void Interact(Player player)
    {
        Debug.LogError(0);
        referencesSO.GetSceneManager().LoadMainMenu();
    }

}
