using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadlyTrigger : MonoBehaviour, IInteractable
{
    public void Interact(Player player)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //player.Dead();
    }
}
