using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStone : ObstacleDisabler
{
    [SerializeField] GameObject _runeRadiance, _rune;

    public override void EnterInteract(Player player)
    {
        base.EnterInteract(player);
        _runeRadiance.SetActive(true);
        _rune.SetActive(true);
    }

}
