using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Added this for Light2D

public class Fire : MonoBehaviour
{
    public GameHandler gameHandler;
    bool isin;
    public Light2D light2D; // Changed the type to Light2D

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
        if (isin && Input.GetKeyDown(KeyCode.Space))
        {
            gameHandler.RemoveWood(1);
            light2D.intensity += 0.01f;
            ResetIntensityChangeTimer();
        }

        timeSinceLastIntensityChange += Time.deltaTime;
        if (timeSinceLastIntensityChange >= 1f)
        {
            DecreaseLightIntensity();
            ResetIntensityChangeTimer();
        }
    }

    void DecreaseLightIntensity()
    {
        if (light2D.intensity > 0f)
        {
            light2D.intensity -= intensityDecreaseRate;
        }
    }

    void ResetIntensityChangeTimer()
    {
        timeSinceLastIntensityChange = 0f;
    }
}
