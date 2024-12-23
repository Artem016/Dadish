using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WinerDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.LogError("Победа");
        }
    }
}
