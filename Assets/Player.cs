using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Resources")]
    public GameHandler gameHandler;
    Animator animator;
    Rigidbody2D rb;

    public int health;
    public int maxHealth;

    public int speed;

    void Start()
    {
        animator = GetComponent<Animator>();
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

        if (horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("isrun", true);
        }
        else
        {
            animator.SetBool("isrun", false);
        }


        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed;
        rb.velocity = movement;

        //flip sprite
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            RemoveHealth(2);
        }
    }

}
