using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform _leftBottomLimition, _rightTopLimitiom;
    [SerializeField] CameraFollo _cameraFollow;

    public void Initialize()
    {
        _cameraFollow.SetCameraLimitons(_leftBottomLimition, _rightTopLimitiom);
    }
}
