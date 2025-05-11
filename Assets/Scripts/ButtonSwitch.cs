using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour, IReactiveInteractable
{
    public Action OnPressed;

    private bool _isPressed = false;

    public bool IsPressed()
    {
        return _isPressed;
    }

    public void EnterInteract()
    {
        _isPressed = true;
        OnPressed?.Invoke();
    }

    public void ExitInteract()
    {
        _isPressed = false;
    }
}
