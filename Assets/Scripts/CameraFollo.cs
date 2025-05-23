using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollo : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform leftDownLimition, rightUpLimition;
    [SerializeField] float _yDifference;

    private void FixedUpdate()
    {
        var newPositionX = _target.position.x;
        var newPositionY = _target.position.y + _yDifference;
        //newPosition.x = _target.position.x;
        //newPosition.y = _target.position.y;
        if(IsCameraPositionWithinBoundsHorizontal(newPositionX, leftDownLimition.position, rightUpLimition.position))
        {
            var newPosition = transform.position;
            newPosition.x = newPositionX;
            transform.position = newPosition;
        }

        if(IsCameraPositionWithinBoundsVertical(newPositionY,leftDownLimition.position, rightUpLimition.position))
        {
            var newPosition = transform.position;
            newPosition.y = newPositionY;
            transform.position = newPosition;
        }

    }

    public void SetCameraLimitons(Transform leftBottom, Transform rightTop)
    {
        leftDownLimition = leftBottom;
        rightUpLimition = rightTop;
    }

    public static bool IsCameraPositionWithinBoundsHorizontal(float cameraPositionX, Vector2 bottomLeftLimit, Vector2 topRightLimit)
    {
        if (cameraPositionX >= bottomLeftLimit.x && cameraPositionX <= topRightLimit.x) 
            return true;
        else
            return false;
    }    
    public static bool IsCameraPositionWithinBoundsVertical(float cameraPositionY, Vector2 bottomLeftLimit, Vector2 topRightLimit)
    {
        if (cameraPositionY >= bottomLeftLimit.y && cameraPositionY <= topRightLimit.y) 
            return true;
        else
            return false;
    }
}
