using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject _blockedVisual;
    [SerializeField] private Button _button;
    [SerializeField] private int _levelNumber;
    [SerializeField] private bool _isBlocked = true;

    private void Start()
    {
        SetBlocked(_isBlocked);
    }

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

    public int GetLevelNumber()
    {
        return _levelNumber;
    }
}
