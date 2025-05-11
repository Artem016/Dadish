using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiButtonController : MonoBehaviour
{
    [SerializeField] List<ButtonSwitch> _buttons;

    [SerializeField] List<GameObject> _obstances;

    private void Awake()
    {
        foreach (var button in _buttons)
        {
            button.OnPressed += TryMultiInteract;
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            button.OnPressed -= TryMultiInteract;
        }
    }

    private bool IsAllButtonPressed()
    {
        foreach (var button in _buttons)
        {
            if(!button.IsPressed())
                return false;
        }
        return true;
    }

    private void TryMultiInteract()
    {
        if (IsAllButtonPressed())
        {
            foreach (var obstance in _obstances) 
            { 
                obstance.SetActive(false);
            }
        }
    }
}
