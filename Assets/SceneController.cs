using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
