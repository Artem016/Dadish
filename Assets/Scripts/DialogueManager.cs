using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] InputAction _nextLineAction;
    [SerializeField] TextMeshProUGUI _dialogueText;
    [SerializeField] GameObject _dialoguePanel;
    [SerializeField] GameObject _iconNextLine;
    [SerializeField] float _charactersPerSecond = 5;
    [SerializeField] DialoguesSO _dialogues;
    [SerializeField] SingletonReferencesSO _referencesSO;
    
    Dialog _currentDialog;
    int _currentLineNumber;
    int _currentLevelNumber;
    bool _isType;

    private void Awake()
    {
        _nextLineAction.performed += OnNextLineButtonClick;
    }

    private void Start()
    {
        VictoryZone.onVictoryZoneInteract += OnVictoryZoneInteract;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        VictoryZone.onVictoryZoneInteract -= OnVictoryZoneInteract;
    }

    public void ShowNextLine()
    {
        if(_currentLineNumber + 1 < _currentDialog.Lines.Count)
        {
            _currentLineNumber++;
            TypeText(_currentDialog.Lines[_currentLineNumber]);
        }
        else
        {
            EndDialogue();
        }
    }

    public void SkipType()
    {
        StopAllCoroutines();
        _dialogueText.text = _currentDialog.Lines[_currentLineNumber];
        _isType = false;
        _iconNextLine.SetActive(true);
    }

    private void EndDialogue()
    {
        _nextLineAction.Disable();
        Debug.Log("End dialogue");
        _nextLineAction.Disable();
        _dialoguePanel.SetActive(false);
        StopAllCoroutines();

        //возможно придется переработать
        _referencesSO.GetSaveManager().AddComplatedLevel(_currentLevelNumber);
        _referencesSO.GetSceneManager().LoadMainMenu();
    }

    private void StartDialogue(Dialog dialog)
    {
        _nextLineAction.Enable();
        Debug.Log("Start dialogue");
        Debug.Log(_dialoguePanel);
        _currentDialog = dialog;
        _dialoguePanel.SetActive(true);
        _currentLineNumber = 0;
        TypeText(_currentDialog.Lines[_currentLineNumber]);
    }

    private void TypeText(string line)
    {
        StartCoroutine(TypeTextCoroutine(line));
    }



    IEnumerator TypeTextCoroutine(string line)
    {
        //_nextLineAction.Disable();
        _isType = true; 
        _iconNextLine.SetActive(false);
        string textBuffer = null;
        _dialogueText.text = "";
        foreach (char c in line)
        {
            textBuffer += c;
            _dialogueText.text = textBuffer;
            yield return new WaitForSeconds(1 / _charactersPerSecond);
        }
        _iconNextLine.SetActive(true);
        _isType = false;
        //_nextLineAction.Enable();
    }

    private void OnVictoryZoneInteract(string dialogName, int levelNumber)
    {
        _currentLevelNumber = levelNumber;
        StartDialogue(_dialogues.GetByName(dialogName));    
    }

    private void OnNextLineButtonClick(InputAction.CallbackContext context)
    {
        if (!_isType)
        {
            ShowNextLine();
        }
        else
        {
            SkipType();
        }
    }
}
