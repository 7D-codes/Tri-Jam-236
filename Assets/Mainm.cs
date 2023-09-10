using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainm : MonoBehaviour
{
    void Start()
    {
        //stop time scale
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;

        //load game scene
        SceneManager.LoadScene("Main");
        //start time scale
    }
}
