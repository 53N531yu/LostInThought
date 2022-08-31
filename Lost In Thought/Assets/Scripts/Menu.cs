using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // public void Begin()
    // {
    //     SceneManager.LoadScene("SampleScene");
    // }

    public void Quit()
    {
        Application.Quit();
    }

    public void _Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
