using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SingletonReferences", menuName = "SingletonRefereces")]
public class GlobalDataSO : ScriptableObject
{
    [SerializeField] private int _levelQuaentuty;

    private int _currentLevelIndex;

    public int CurrentLevelIndex
    {
        get => _currentLevelIndex;
        set
        {
            if (value > 0 && value < _levelQuaentuty)
                _currentLevelIndex = value;
        }
    }
}
