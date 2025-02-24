using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void Run()
    {
        _animator.SetBool("Run", true);
    }

    public void StopRun()
    {
        _animator.SetBool("Run", false);
    }

    public void Jump()
    {
        _animator.SetBool("Jump", true);
    }

    public void Landing()
    {
        _animator.SetBool("Jump", false);
    }

    public void Dead()
    {
        _animator.SetTrigger("Dead");
    }
}
