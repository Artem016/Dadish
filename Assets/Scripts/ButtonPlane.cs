using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlane : MonoBehaviour
{
    private void SetPressedVisual()
    {
        var newScale = transform.localScale;
        newScale.y = 0.5f;
        transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetPressedVisual();
    }
}
