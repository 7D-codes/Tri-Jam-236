using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    public Player Player;
    public float speed;
    public float visionRadius = 5.0f;
    public LayerMask playerLayer;

    private bool isIdle = true;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (isIdle)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }

        // Check for player in vision area and switch state if necessary
        if (Physics2D.OverlapCircle(transform.position, visionRadius, playerLayer) && isIdle)
        {
            isIdle = false;
        }
        else if (!Physics2D.OverlapCircle(transform.position, visionRadius, playerLayer) && !isIdle)
        {
            isIdle = true;
        }
        else if (!isIdle)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //audio
            Player.RemoveHealth(2);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
