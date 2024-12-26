using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SavesSO", menuName = "SavesSO")]
public class SavesSO : ScriptableObject
{
    public List<int> ComletedLevels = new List<int>();
}
