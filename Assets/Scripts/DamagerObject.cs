using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerObject : MonoBehaviour, IInteractable
{
    public void Interact(Player player)
    {
        player.Dead();
    }
}
