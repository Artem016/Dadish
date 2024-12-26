using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonsManager : MonoBehaviour
{
    [SerializeField] private List<LevelButton> _levelButtons;
    [SerializeField] private SavesSO _saves;

    private void Awake()
    {
        SaveManager.OnLoadSave += OnSaveLoad;
        SaveManager.OnLoadEmptySave += OnSaveLoad;
    }

    private void OnDestroy()
    {
        SaveManager.OnLoadSave -= OnSaveLoad;
        SaveManager.OnLoadEmptySave -= OnSaveLoad;
    }

    public void OnSaveLoad()
    {
        UpdateButtonState();
    }

    private void OnEnable()
    {
        UpdateButtonState();
    }

    public void UpdateButtonState()
    {
        foreach (var levelButton in _levelButtons)
        {
            if (_saves.ComletedLevels.Contains(levelButton.GetLevelNumber()))
            {
                levelButton.SetBlocked(false);
            }
        }
    }
}
