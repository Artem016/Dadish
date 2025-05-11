using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ObstacleDisabler : MonoBehaviour, IInteractable
{
    [SerializeField] List<GameObject> _obstacles;

    bool _active = false;

    public virtual void Interact(Player player)
    {
        if (!_active)
        {
            _active = true;
            foreach(var obstacle in _obstacles)
            {
                obstacle.SetActive(false);
            }
        }
    }
}
