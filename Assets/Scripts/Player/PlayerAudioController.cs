using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] AudioClip _jump;
    [SerializeField] AudioClip _run;
    [SerializeField] AudioClip _dead;

    AudioSource _audioSource;
    public bool IsRun {  get; private set; }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        _audioSource.PlayOneShot(_jump);
    }

    public void Run()
    {
        _audioSource.clip = _run;
        _audioSource.Play();
        IsRun = true;
    }

    public void StopRun()
    {
        _audioSource.Stop();
        IsRun = false;
    }

    public void Dead()
    {
        _audioSource.PlayOneShot(_dead);
    }
}
