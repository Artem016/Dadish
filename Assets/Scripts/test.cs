using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void TestSaveButtonOnClick()
    {
        SaveManager.SaveGame(new SaveData { name = "00000"});
    }
}
