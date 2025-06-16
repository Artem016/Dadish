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
    [SerializeField] SingletonReferencesSO references;
    [SerializeField] SettingsSO settings;

    public void SetMusicVolume()
    {
        settings.MusicVolume = _backroundMusicSlider.value;
        _mixer.SetFloat("music", Mathf.Log10(settings.MusicVolume) * 20);
        
    }    
    public void SetPlayerVolume()
    {
        settings.SoundVolume = _playerSlider.value;
        _mixer.SetFloat("player", Mathf.Log10(settings.SoundVolume) * 20);
    }

    private void Load()
    {
        _backroundMusicSlider.value = settings.MusicVolume;
        _playerSlider.value = settings.SoundVolume;
        SetPlayerVolume();
        SetMusicVolume();
    }

    private void OnDestroy()
    {
        references.GetSaveManager().Save();
    }

    private void Start()
    {
        Load();
    }
}
