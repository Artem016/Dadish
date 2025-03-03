using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] AudioClip _jump;
    [SerializeField] AudioClip _run;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        _audioSource.PlayOneShot(_jump);
    }

    public void StartRun()
    {
        //_audioSource.
    }
}
