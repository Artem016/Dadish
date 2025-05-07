using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPushableInteractable interactable;
        collision.TryGetComponent(out interactable);
        if (interactable != null)
            interactable.EnterInteract();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IPushableInteractable interactable;
        collision.TryGetComponent(out interactable);
        if (interactable != null)
            interactable.ExitInteract();
    }
}
