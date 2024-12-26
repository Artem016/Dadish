using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject _blockedVisual;
    [SerializeField] private Button _button;
    private bool _isBlocked = false;
    public void SetBlocked(bool isBlocked)
    {
        _isBlocked = isBlocked;
        if (_isBlocked)
        {
            _blockedVisual.SetActive(true);
            _button.interactable = false;
        }
        else
        {
            _blockedVisual.SetActive(false);
            _button.interactable = true;
        }
    }
}
