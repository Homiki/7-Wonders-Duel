using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardDeck1 : MonoBehaviour
{
    public GameObject[] cardNeeded;
    public GameObject[] emptyCard;

    public List<GameObject> cards;

    public int random;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            do
            {
                random = UnityEngine.Random.Range(0, cardNeeded.Length);
                Debug.Log(random);
            } while (cards.Contains(cardNeeded[random]));
            cards.Add(cardNeeded[random]);
        }
    }
}
