using System;

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorsSO", menuName = "Colors")]
public class ColorsSO : ScriptableObject
{
    public List<ColorItem> Colors;
}

[Serializable]
public class ColorItem
{
    public string Name;
    public string Discription;
    public Color Color;
}
