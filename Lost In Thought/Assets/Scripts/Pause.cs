using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool Paused = false; 

    public GameObject pause;
    public GameObject MenuFr;
    public GameObject QuitFr;

    void Start()
    {
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pausing();
            }
        }
    }

    public void Pausing()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void LoadMenu()
    {
        MenuFr.SetActive(true);
        pause.SetActive(false);
    }

    public void Quit()
    {
        QuitFr.SetActive(true);
        pause.SetActive(false);
    }

    public void LoadMenuFr()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quitfr()
    {
        Application.Quit();
    }

    public void No()
    {
        MenuFr.SetActive(false);
        QuitFr.SetActive(false);
        pause.SetActive(true);
    }
}
