using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToMarket : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }

    }

}