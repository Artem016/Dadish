using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    private GameObject _selectPanel, _previousPanel;

    [SerializeField] GameObject _restartPanel, _pausePanel, _settingPanel;
    [SerializeField] GameObject _blackout;

    public void OpenRestartPanel()
    {
        _blackout.SetActive(true);
        if (_selectPanel != null)
        {
            _selectPanel.SetActive(false);
            _previousPanel = _selectPanel;
        }
        _selectPanel = _restartPanel;
        _selectPanel.SetActive(true);        
    }

    public void OpenPausePanel()
    {
        _blackout.SetActive(true);
        if (_selectPanel != null)
        {
            _selectPanel.SetActive(false);
            _previousPanel = _selectPanel;
        }
            
        _selectPanel = _pausePanel;
        _selectPanel.SetActive(true);
    }

    public void OpenSettingPanel()
    {
        _blackout.SetActive(true);
        if (_selectPanel != null)
        {
            _selectPanel.SetActive(false);
            _previousPanel = _selectPanel;
        }
        _selectPanel = _settingPanel;
        _selectPanel.SetActive(true);
    }

    public void OpenPreveousPanel()
    {
        _blackout.SetActive(true);
        _selectPanel.SetActive(false);
        _previousPanel.SetActive(true);
        GameObject tempPanel = _selectPanel;
        _selectPanel = _previousPanel;
        _previousPanel = tempPanel;
    }

    public void CloseSelectPanel()
    {
        _blackout.SetActive(false);
        _selectPanel.SetActive(false);
        _previousPanel = _selectPanel;
        _selectPanel = null;
    }
}
