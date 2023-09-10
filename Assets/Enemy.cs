using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    public float speed;
    public float visionRadius = 5.0f;
    public LayerMask playerLayer;

    private bool isIdle = true;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float lerpTime = 2.0f;

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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
