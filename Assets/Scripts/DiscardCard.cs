using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardCard : MonoBehaviour
{
    public Vector3 cardScale;

    public GameObject Graveyard;

    BoxCollider bc;
    public CardValues values;
    public Reso resources;
    LevelLoader levelLoader;

    public ChangingButton button;


    // Start is called before the first frame update
    void Start()
    {

        Graveyard = GameObject.FindGameObjectWithTag("Graveyard");
        cardScale = this.transform.localScale;

        bc = GetComponent<BoxCollider>();
        values = GetComponent<CardValues>();
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();

        levelLoader = GameObject.FindGameObjectWithTag("Respawn").GetComponent<LevelLoader>();

        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (bc.Raycast(ray, out hit, 100.0f))
            {
                Discard();
            }
        }

    }


    void Discard()
    {
        if (button.isYourTurn == true && button.isEnemyTurn == false)
        {
            this.transform.position = Graveyard.transform.position;
            this.transform.SetParent(Graveyard.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            resources.gold += (2 + resources.playerYellowQuantity);

            levelLoader.cardsRemaining -= 1;
        }
        else
        {
            this.transform.position = Graveyard.transform.position;
            this.transform.SetParent(Graveyard.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            resources.enemyGold += (2 + resources.enemyYellowQuantity);

            levelLoader.cardsRemaining -= 1;
        }


        //We need to add graveyard system

    }
}
