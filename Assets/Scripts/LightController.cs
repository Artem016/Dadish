using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject _lightContainer;

    void Start()
    {
        Player.onPlayerDies += LightOff;
    }

    private void OnDestroy()
    {
        Player.onPlayerDies -= LightOff;
    }

    void LightOff()
    {
        _lightContainer.SetActive(false);
    }

    void LightOn()
    {
        _lightContainer.SetActive(true);
    }
}
