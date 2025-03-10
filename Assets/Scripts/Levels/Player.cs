using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerAnimationController _animationController;
    PlayerAudioController _audioController;
    PlayerMovement _movementController;

    public static Action onPlayerDies;
    private bool _isCollectableTake = false;


    private void Awake()
    {
        _animationController = GetComponent<PlayerAnimationController>();
        _movementController = GetComponent<PlayerMovement>();
        _audioController = GetComponent<PlayerAudioController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInteractable interactable;
        collision.gameObject.TryGetComponent(out interactable);
        if (interactable != null)
            interactable.Interact(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable;
        collision.TryGetComponent(out interactable);
        if (interactable != null)
            interactable.Interact(this);
    }

    public void Dead()
    {
        onPlayerDies?.Invoke();
        _animationController.Dead();
        _audioController.Dead();
        _movementController.StopMove();
        _movementController.enabled = false;

    }

    public void TakeCollectable()
    {
        _isCollectableTake = true;
        Debug.Log("Подобран коллекционный предмет");
    }


}
