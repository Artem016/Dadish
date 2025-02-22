using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStone : ObstacleDisabler
{
    [SerializeField] GameObject _runeRadiance;

    public override void Interact(Player player)
    {
        base.Interact(player);
        _runeRadiance.SetActive(true);
    }

}
