using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public GameObject gameOverScene;
    public GameObject winScene;
    public string nextSceneName;
    public void restartGame()
    {
        Debug.Log("restartGame()");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //SceneManager.GetActiveScene().name
    }
    public void nextScene()
    {
        SceneManager.LoadScene(nextSceneName); //SceneManager.GetActiveScene().name
    }

    public void gameOverUI()
    {
        gameOverScene.SetActive(true);
    }

    public void successUI()
    {
        winScene.SetActive(true);
    }
}
