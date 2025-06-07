using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _backroundMusicSlider, _playerSlider;
    [SerializeField] GameObject _pauseMenu;

    public void SetMusicVolume()
    {
        float volume = _backroundMusicSlider.value;
        _mixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }    
    public void SetPlayerVolume()
    {
        float volume = _playerSlider.value;
        _mixer.SetFloat("player", Mathf.Log10(volume) * 20);
    }

    public void BackToPauseMenu_Click()
    {
        _pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }

}
