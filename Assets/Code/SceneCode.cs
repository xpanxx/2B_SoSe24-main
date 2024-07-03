using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCode : MonoBehaviour
{

    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
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

