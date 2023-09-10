using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Maingh : MonoBehaviour
{
    [Header("Resources")]
    public AudioSource Main;
    public AudioSource Win;


    private float lastWinSoundTime = 0f;
    public float winSoundInterval = 20f; // Interval for playing the win sound

    void Start()
    {

        // Start playing the Main audio source
        Main.Play();
    }

   

    void Update()
    {
        // Check if it's time to play the win sound
        if (Time.time - lastWinSoundTime >= winSoundInterval)
        {
            // Play the Win sound
            Win.Play();
            lastWinSoundTime = Time.time; // Update the last played time
        }
    }
}
