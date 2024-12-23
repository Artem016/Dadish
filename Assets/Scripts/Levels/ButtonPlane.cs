using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlane : MonoBehaviour, IInteractable
{
    public Action onButtonPress;

    private void Start()
    {
        onButtonPress += SetPressedVisual;
    }

    private void OnDestroy()
    {
        onButtonPress -= SetPressedVisual;
    }

    private void SetPressedVisual()
    {
        var newScale = transform.localScale;
        newScale.y = 0.5f;
        transform.localScale = newScale;
    }

    public void Interact(Player player)
    {
        onButtonPress?.Invoke();
    }
}
