using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITriggerReactiveButton triggerReactive;
        collision.gameObject.TryGetComponent(out triggerReactive);

        if(triggerReactive != null )
        {
            isPressed = true;
            Debug.LogError("press");
        }
            
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ITriggerReactiveButton triggerReactive;
        collision.gameObject.TryGetComponent(out triggerReactive);

        if (triggerReactive != null)
        {
            isPressed = true;
            Debug.LogError("not press");
        }

    }
}
