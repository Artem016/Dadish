using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action onPlayerDies;
    private bool _isCollectableTake = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInteractable interactable;
        collision.gameObject.TryGetComponent<IInteractable>(out interactable);
        if (interactable != null)
            interactable.Interact(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable;
        collision.TryGetComponent<IInteractable>(out interactable);
        if (interactable != null)
            interactable.Interact(this);
    }

    public void Dead()
    {
        Debug.LogError(0);
        onPlayerDies?.Invoke();
    }

    public void TakeCollectable()
    {
        _isCollectableTake = true;
        Debug.Log("Подобран коллекционный предмет");
    }
}
