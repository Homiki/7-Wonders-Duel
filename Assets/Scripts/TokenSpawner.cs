using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TokenSpawner : MonoBehaviour
{
    public int needToken;
    // 0 --> dont need a card
    // 1 --> need a card

    private TokenDeck token;
    private bool spawn = false;
    private GameObject tokenSpawner;

    public int rand;

    void Start()
    {
        token = GameObject.FindGameObjectWithTag("Deck").GetComponent<TokenDeck>();
        Invoke(nameof(Spawner), 0.1f);
        tokenSpawner = GameObject.Find("TokenSpawner");
    }
    void Update()
    {

    }
    public void Spawner()
    {
        if (spawn == false)
        {
            if (needToken == 0)
            {

            }
            else if (needToken == 1)
            {
                Instantiate(token.tokens[rand], transform.position, token.tokenNeeded[rand].transform.rotation);
                spawn = true;
            }
            spawn = true;
            tokenSpawner.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TokenSpawner"))
        {
            Destroy(gameObject);
        }
    }



}