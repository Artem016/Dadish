using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject _blockedVisual, _unBlockVisual;
    [SerializeField] private Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private int _levelNumber;
    [SerializeField] private bool _isBlocked = true;
    [SerializeField] private Color _blockColorText, _unBlockColorText;

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
            _unBlockVisual.SetActive(false);
            _text.color = _blockColorText;
            _button.interactable = false;
        }
        else
        {
            _blockedVisual.SetActive(false);
            _unBlockVisual.SetActive(true);
            _text.color = _unBlockColorText;
            _button.interactable = true;
        }
    }

    public int GetLevelNumber()
    {
        return _levelNumber;
    }
}
