using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    public void EnterInteract(Player player)
    {
        player.TakeCollectable();
        Destroy(gameObject);
    }
}
