using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameHandler : MonoBehaviour
{
    [Header("Resources")]
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI Health;
    

    public int trees = 5;
    public int wood;
    public int maxWood;

    public void AddWood(int amount)
    {
        wood += amount;
        if (wood > maxWood)
        {
            wood = maxWood;
        }

        woodText.text = wood.ToString();
    }

    public void RemoveWood(int amount)
    {
        wood -= amount;
        if (wood < 0)
        {
            wood = 0;
        }

        woodText.text = wood.ToString();

    }

    public void win()
    {
        Debug.Log("You win!");
    }
}
