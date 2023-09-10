using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameHandler gameHandler;
    bool isin;

    void Start()
    {
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
        }
    }
}
