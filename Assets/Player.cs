using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Resources")]
    public GameHandler gameHandler;
    Rigidbody2D rb;

    public int health;
    public int maxHealth;

    public int speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AddHealth(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void RemoveHealth(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
    }
    
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed;
        rb.velocity = movement;
    }

}
