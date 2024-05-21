using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public void StartGame()
    {

        SceneManager.LoadScene("Game");

    }

    public void QuitGame()
    {

        Application.Quit();

    }

    public void BacktoMenu()
    {

        SceneManager.LoadScene("Menu");

    }

    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
