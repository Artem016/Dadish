using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action onPlayerDies;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError(collision.gameObject.tag);
        if(collision.gameObject.tag == "Enemy")
            onPlayerDies?.Invoke();
    }
}
