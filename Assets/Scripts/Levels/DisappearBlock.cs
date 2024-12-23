using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBlock : MonoBehaviour
{
    [SerializeField] private ButtonPlane _buttonPlane;

    private void Start()
    {
        _buttonPlane.onButtonPress += OnButtonPlanePress;  
    }

    private void OnDestroy()
    {
        _buttonPlane.onButtonPress -= OnButtonPlanePress;
    }

    private void OnButtonPlanePress()
    {
        Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
