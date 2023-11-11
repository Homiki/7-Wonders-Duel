using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardSpawner : MonoBehaviour
{
    public int needCard;
    // 0 --> dont need a card
    // 1 --> need a card

    private CardDeck1 deck1;
    private bool spawned = false;
    private GameObject spawnPanels;

    public int rand;

    void Start()
    {
        deck1 = GameObject.FindGameObjectWithTag("Deck").GetComponent<CardDeck1>();
        Invoke(nameof(Spawn), 0.1f);
        spawnPanels = GameObject.Find("SpawnPanels");
    }
    void Update()
    {

    }
    public void Spawn()
    {
        if (spawned == false)
        {
            if (needCard == 0)
            {

            }
            else if (needCard == 1)
            {
                Instantiate(deck1.cards[rand], transform.position, deck1.cardNeeded[rand].transform.rotation);
                spawned = true;
            }
            spawned = true;
            spawnPanels.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}