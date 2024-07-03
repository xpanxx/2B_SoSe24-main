using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoortoGarden : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }

    }
    
}
