using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] SelectedLevelDataSO _selectedLevelData;
    [SerializeField] List<LevelManager> _levels;

    void Start()
    {
        if( _selectedLevelData.CurrentLevel < _levels.Count)
        {
            _levels[_selectedLevelData.CurrentLevel].gameObject.SetActive(true);
            _levels[_selectedLevelData.CurrentLevel].Initialize();
        }
    }
}
