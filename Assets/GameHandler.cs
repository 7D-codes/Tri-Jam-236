using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [Header("Resources")]
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI Health;
    public AudioSource Main;
    public AudioSource Win;
    public Player player;
    public Animator animator;

    public int trees = 5;
    public int wood;
    public float score;

    private float lastWinSoundTime = 0f;
    public float winSoundInterval = 20f; // Interval for playing the win sound

    void Start()
    {
        woodText.text = ("wood : " + wood).ToString();
        Health.text = ("HP : " + player.health).ToString();

        // Start playing the Main audio source
        Main.Play();
    }

    void FixedUpdate()
    {
        Health.text = ("HP : " + player.health).ToString();
    }

    public void AddWood(int amount)
    {
        wood += amount;

        woodText.text = ("wood : " + wood).ToString();
    }

    public void RemoveWood(int amount)
    {
        wood -= amount;
        if (wood < 0)
        {
            wood = 0;
        }

        woodText.text = ("wood : " + wood).ToString();
    }

    public void win()
    {
        Debug.Log("You win!");
        animator.SetBool("won", true);
    }

    public void lose()
    {
        Debug.Log("You lose!");
        animator.SetBool("lost", true);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Mainmenu");
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
