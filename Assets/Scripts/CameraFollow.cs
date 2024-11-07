using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        var newPosition = transform.position;
        newPosition.x = _target.position.x;
        transform.position = newPosition;
    }
}
