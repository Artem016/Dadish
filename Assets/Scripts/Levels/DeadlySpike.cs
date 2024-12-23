using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlySpike : MonoBehaviour, IInteractable
{
    public void Interact(Player player)
    {
        KillPlayer(player);
    }

    private void KillPlayer(Player player)
    {
        player.Dead();
    }
}
