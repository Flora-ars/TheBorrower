using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("Garden");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync("Garden", LoadSceneMode.Single);
    }
}
