using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour, IInteractable
{
    [SerializeField] SingletonReferencesSO referencesSO;

    public void Interact(Player player)
    {
        referencesSO.GetSceneManager().LoadMainMenu();
    }

}
