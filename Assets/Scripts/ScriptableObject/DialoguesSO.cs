using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DialoguesSO", menuName = "Dialogues")]
public class DialoguesSO : ScriptableObject
{
    [SerializeField] List<Dialog> dialogues;

    public Dialog GetByName(string name)
    {
        var dialog = dialogues.FirstOrDefault(d => d.DialogueName == name);
        return dialog;
    }
}

[Serializable]
public class Dialog
{
    public string DialogueName;
    public List<string> Lines;
}