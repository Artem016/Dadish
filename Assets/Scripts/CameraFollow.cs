using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform leftDownLimition, rightUpLimition;

    private void FixedUpdate()
    {
        var newPosition = transform.position;
        newPosition.x = _target.position.x;
        if(IsCameraPositionWithinBounds(newPosition, leftDownLimition.position, rightUpLimition.position))
            transform.position = newPosition;
    }

    private bool IsCameraPositionWithinBounds(Vector2 cameraPosition, Vector2 bottomLeftLimit, Vector2 topRightLimit)
    {
        if (cameraPosition.x >= bottomLeftLimit.x && cameraPosition.y >= bottomLeftLimit.y && cameraPosition.x <= topRightLimit.x && cameraPosition.y <= topRightLimit.y) 
            return true;
        else
            return false;
    }
}
