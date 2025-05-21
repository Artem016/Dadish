using System;

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
        HandleEnterInteraction(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleEnterInteraction(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HandleExitInteraction(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HandleExitInteraction(collision.gameObject);
    }

    public void Dead()
    {
        Debug.Log("Player dead");
        StopMove();
        onPlayerDies?.Invoke();
        _animationController.Dead(); 
        _audioController.Dead();
    }

    public void TakeCollectable()
    {
        _isCollectableTake = true;
        Debug.Log("Подобран коллекционный предмет");
    }

    public void StopMove()
    {
        _audioController.EndRun();
        _animationController.StopRun();
        _movementController.Stop();
        _movementController.enabled = false;  
    }

    private void HandleEnterInteraction(GameObject other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
            interactable.Interact(this);

        if (other.TryGetComponent<IReactiveInteractable>(out var reactiveInteractable))
            reactiveInteractable.EnterInteract();
    }

    private void HandleExitInteraction(GameObject other)
    {
        if (other.TryGetComponent<IReactiveInteractable>(out var reactiveInteractable))
            reactiveInteractable.ExitInteract();
    }
}
