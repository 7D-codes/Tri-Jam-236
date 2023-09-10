using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Added this for Light2D

public class Fire : MonoBehaviour
{
    public GameHandler gameHandler;
    public Player player;
    bool isin;
    public Light2D light2D; // Changed the type to Light2D
    public SpriteRenderer spriteRenderer;

    private float intensityDecreaseRate = 0.005f;
    private float timeSinceLastIntensityChange = 0f;

    void Start()
    {
        light2D = GetComponent<Light2D>(); // Removed UnityEngine.Rendering.Universal.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isin = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isin = false;
        }
    }

    void Update()
    {
        if (light2D.intensity >= 2f)
        {
            gameHandler.win();
        }
        else if(light2D.intensity <= 0f)
        {
            gameHandler.lose();
        }
        if(isin)
        {
            if (Time.time % 1 < 0.1)
            {
                player.AddHealth(1);
                gameHandler.Health.text = ("HP : " + player.health).ToString();
            }
        }
        if (gameHandler.score <= 100f)
        {
           
            if (isin && Input.GetKeyDown(KeyCode.Space))
            {
                gameHandler.score += 1f;
                gameHandler.RemoveWood(1);
                light2D.intensity += 0.01f;
                spriteRenderer.color += new Color(0,0,0,0.02f);
                ResetIntensityChangeTimer();
            }

            timeSinceLastIntensityChange += Time.deltaTime;
            if (timeSinceLastIntensityChange >= 1f)
            {
                DecreaseLightIntensity();
                ResetIntensityChangeTimer();
            }
        }
        else
        {
            gameHandler.win();
        }
    }

    void DecreaseLightIntensity()
    {
        if (light2D.intensity > 0f)
        {
            light2D.intensity -= intensityDecreaseRate;
            spriteRenderer.color -= new Color(0,0,0,0.05f);
        }
    }

    void ResetIntensityChangeTimer()
    {
        timeSinceLastIntensityChange = 0f;
    }
}
