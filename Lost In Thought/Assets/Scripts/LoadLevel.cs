using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "door1")
        {
            SceneManager.LoadScene("Test");
        }
        if (other.tag == "door2")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
