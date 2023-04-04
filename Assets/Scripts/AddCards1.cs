using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCards1 : MonoBehaviour
{
    public bool spawnedd;
    private CardDeck1 deck1;

    void Start()
    {
        deck1 = GameObject.FindGameObjectWithTag("Deck").GetComponent<CardDeck1>();
        deck1.cards.Add(this.gameObject);
        Debug.Log("Spawned");
        //spawnedd = true;
    }

    // if spawned w update 
    void Update()
    {
        if(spawnedd == true)
        {
            //deck1.cards.Remove(this.gameObject);
            //Destroy(gameObject);
            //Debug.Log("Destroyed");
            //deck1.cards.Add(this.gameObject);
        }
        
    }

}
