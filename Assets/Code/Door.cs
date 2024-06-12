using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }

    }
    public class SceneController
    {
        internal static object instance;

        public static implicit operator SceneController(SceneCode v)
        {
            throw new NotImplementedException();
        }
    }
}
