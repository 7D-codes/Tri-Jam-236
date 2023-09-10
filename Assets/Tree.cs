using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameHandler gameHandler;
    private int wood;

    bool isin =false;

    void Start()
    {
        wood = UnityEngine.Random.Range(2, 11); // Randomize wood value between 2 and 10
        Debug.Log("This tree has " + wood + " wood.");
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        gameHandler.trees++;
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
            if (wood > 0)
            {
                gameHandler.AddWood(1);
                wood--;
            }
            else
            {
                Destroy(gameObject);
                gameHandler.trees--;
            }
            
        }
    }
}
