using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveOnClick : MonoBehaviour
{
    public Vector3 town;
    public Vector3 cardScale;

    public int Color;
    //Brown --- 1
    //Yellow -- 2
    //Blue ---- 3
    //Red ----- 4
    //Green --- 5
    //Grey ---- 6
    //Purpple - 7

    //public int yellowQuantity;

    //-----------SpawnPanels-----------
    public GameObject PlayerGreyTown;
    public GameObject PlayerBrownTown;
    public GameObject PlayerYellowTown;
    public GameObject PlayerRedTown;
    public GameObject PlayerBlueTown;
    public GameObject PlayerGreenTown;
    public GameObject PlayerPurpleTown;

    //-----------EnemySpawnPanels-----------
    public GameObject EnemyGreyTown;
    public GameObject EnemyBrownTown;
    public GameObject EnemyYellowTown;
    public GameObject EnemyRedTown;
    public GameObject EnemyBlueTown;
    public GameObject EnemyGreenTown;
    public GameObject EnemyPurpleTown;

    public GameObject Graveyard;
    
    //-----------Cards-----------
    public GameObject BrownCard;
    public GameObject YellowCard;
    public GameObject GreyCard;
    public GameObject BlueCard;
    public GameObject RedCard;
    public GameObject GreenCard;
    public GameObject PurpleCard;

    BoxCollider bc;
    public CardValues values;
    public Reso resources;
    MoveOnClick moveonclick;
    Rigidbody rb;
    LevelLoader levelLoader;

    public ChangingButton button;

    // Start is called before the first frame update
    void Start()
    {
        town.z = 5;
        cardScale = this.transform.localScale; // Maybe to edit!!!

        //-----------DropAreas-----------
        PlayerGreyTown = GameObject.FindGameObjectWithTag("DropAreaGrey");
        PlayerBrownTown = GameObject.FindGameObjectWithTag("DropAreaBrown");
        PlayerYellowTown = GameObject.FindGameObjectWithTag("DropAreaYellow");
        PlayerRedTown = GameObject.FindGameObjectWithTag("DropAreaRed");
        PlayerBlueTown = GameObject.FindGameObjectWithTag("DropAreaBlue");
        PlayerGreenTown = GameObject.FindGameObjectWithTag("DropAreaGreen");
        //PlayerPurpleTown = GameObject.FindGameObjectWithTag("DropAreaPurple");

        //-----------EnemyDropAreas-----------
        EnemyGreyTown = GameObject.FindGameObjectWithTag("EnemyDropAreaGrey");
        EnemyBrownTown = GameObject.FindGameObjectWithTag("EnemyDropAreaBrown");
        EnemyYellowTown = GameObject.FindGameObjectWithTag("EnemyDropAreaYellow");
        EnemyRedTown = GameObject.FindGameObjectWithTag("EnemyDropAreaRed");
        EnemyBlueTown = GameObject.FindGameObjectWithTag("EnemyDropAreaBlue");
        EnemyGreenTown = GameObject.FindGameObjectWithTag("EnemyDropAreaGreen");
        //PlayerPurpleTown = GameObject.FindGameObjectWithTag("EnemyDropAreaPurple");

        //-----------Graveyard--------
        Graveyard = GameObject.FindGameObjectWithTag("Graveyard");

        //-----------Cards-----------
        BrownCard = GameObject.FindGameObjectWithTag("Era1Brown");
        YellowCard = GameObject.FindGameObjectWithTag("Era1Yellow");
        GreyCard = GameObject.FindGameObjectWithTag("Era1Grey");
        BlueCard = GameObject.FindGameObjectWithTag("Era1Blue");
        RedCard = GameObject.FindGameObjectWithTag("Era1Red");
        GreenCard = GameObject.FindGameObjectWithTag("Era1Green");
        //PurpleCard = GameObject.FindGameObjectWithTag("Era1Purple");

        bc = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        values = GetComponent<CardValues>();
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
        moveonclick = gameObject.GetComponent<MoveOnClick>();
        this.gameObject.tag = "Blocked";

        levelLoader = GameObject.FindGameObjectWithTag("Respawn").GetComponent<LevelLoader>();

        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (bc.Raycast(ray, out hit, 100.0f))
            {
                AddToTown();
                this.gameObject.tag = "Dropped";
            }
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    RaycastHit hit;

        //    if (bc.Raycast(ray, out hit, 100.0f))
        //    {
        //        DiscardCard();
        //    }
        //}


        ParentChecker();


    }

    void AddToTown()
    {
        //-----------------------Transform card to player drop area-------------------
        if (Color == 1 && resources.gold >= values.cost && button.isYourTurn == true)
        {
            this.transform.position = PlayerBrownTown.transform.position;
            this.transform.SetParent(PlayerBrownTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.glina += values.glinaV;
            resources.stone += values.kamienV;
            resources.wood += values.drewnoV;
            resources.gold -= values.cost;

            //Think about to add freeze rotation!!!

            levelLoader.cardsRemaining -= 1;

        }
        else if (Color == 6 && resources.gold >= values.cost && button.isYourTurn == true)
        {
            this.transform.position = PlayerGreyTown.transform.position;
            this.transform.SetParent(PlayerGreyTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.glass += values.glassV;
            resources.papirus += values.papirusV;
            resources.gold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 2 && resources.gold >= values.cost && button.isYourTurn == true)
        {
            this.transform.position = PlayerYellowTown.transform.position;
            this.transform.SetParent(PlayerYellowTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";
            resources.playerYellowQuantity++;

            resources.gold += values.goldV;
            resources.PZ += values.PZ;
            resources.gold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 3 && resources.gold >= values.cost && button.isYourTurn == true)
        {
            this.transform.position = PlayerBlueTown.transform.position;
            this.transform.SetParent(PlayerBlueTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.PZ += values.PZ;
            resources.gold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 4 && resources.gold >= values.cost && button.isYourTurn == true)
        {
            this.transform.position = PlayerRedTown.transform.position;
            this.transform.SetParent(PlayerRedTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.PZ += values.PZ;
            resources.gold -= values.cost;
            resources.military += values.militaryV;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 5 && resources.gold >= values.cost && button.isYourTurn == true)
        {
            this.transform.position = PlayerGreenTown.transform.position;
            this.transform.SetParent(PlayerGreenTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.gold += values.goldV;
            resources.PZ += values.PZ;
            resources.gold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        //else if (Color == 7 && button.isYourTurn == true)
        //{
        //    this.transform.position = PlayerPurpleTown.transform.position;
        //    this.transform.SetParent(PlayerPurpleTown.transform);
        //    this.tag = "Dropped";
        //    cardScale = this.transform.localScale;
        //    this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);


        //resources.gold -= values.cost;

        //levelLoader.cardsRemaining -= 1;
        //}


        //-----------------------Transform card to enemy drop area-------------------

        if (Color == 1 && resources.enemyGold >= values.cost && button.isEnemyTurn == true)
        {
            this.transform.position = EnemyBrownTown.transform.position;
            this.transform.SetParent(EnemyBrownTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.enemyGlina += values.glinaV;
            resources.enemyStone += values.kamienV;
            resources.enemyWood += values.drewnoV;
            resources.enemyGold -= values.cost;

            //Think about to add freeze rotation!!!

            levelLoader.cardsRemaining -= 1;

        }
        else if (Color == 6 && resources.enemyGold >= values.cost && button.isEnemyTurn == true)
        {
            this.transform.position = EnemyGreyTown.transform.position;
            this.transform.SetParent(EnemyGreyTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.enemyGlass += values.glassV;
            resources.enemyPapirus += values.papirusV;
            resources.enemyGold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 2 && resources.enemyGold >= values.cost && button.isEnemyTurn == true)
        {
            this.transform.position = EnemyYellowTown.transform.position;
            this.transform.SetParent(EnemyYellowTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";
            resources.enemyYellowQuantity++;

            resources.enemyGold += values.goldV;
            resources.enemyPZ += values.PZ;
            resources.enemyGold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 3 && resources.enemyGold >= values.cost && button.isEnemyTurn == true)
        {
            this.transform.position = EnemyBlueTown.transform.position;
            this.transform.SetParent(EnemyBlueTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.enemyPZ += values.PZ;
            resources.enemyGold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 4 && resources.enemyGold >= values.cost && button.isEnemyTurn == true)
        {
            this.transform.position = EnemyRedTown.transform.position;
            this.transform.SetParent(EnemyRedTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.enemyPZ += values.PZ;
            resources.enemyGold -= values.cost;
            resources.enemyMilitary += values.militaryV;

            levelLoader.cardsRemaining -= 1;
        }
        else if (Color == 5 && resources.enemyGold >= values.cost && button.isEnemyTurn == true)
        {
            this.transform.position = EnemyGreenTown.transform.position;
            this.transform.SetParent(EnemyGreenTown.transform);
            cardScale = this.transform.localScale;
            this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
            this.gameObject.tag = "Dropped";

            resources.enemyGold += values.goldV;
            resources.enemyPZ += values.PZ;
            resources.enemyGold -= values.cost;

            levelLoader.cardsRemaining -= 1;
        }
        //else if (Color == 7 && button.isEnemyTurn == true)
        //{
        //    this.transform.position = PlayerPurpleTown.transform.position;
        //    this.transform.SetParent(PlayerPurpleTown.transform);
        //    this.tag = "Dropped";
        //    cardScale = this.transform.localScale;
        //    this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);


        //resources.gold -= values.cost;

        //levelLoader.cardsRemaining -= 1;
        //}
    }

    //void DiscardCard()
    //{
    //    if(button.isYourTurn == true && button.isEnemyTurn==false)
    //    {
    //        this.transform.position = Graveyard.transform.position;
    //        this.transform.SetParent(Graveyard.transform);
    //        cardScale = this.transform.localScale;
    //        this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
    //        resources.gold += (2 + resources.playerYellowQuantity);

    //        levelLoader.cardsRemaining -= 1;
    //    }
    //    else
    //    {
    //        this.transform.position = Graveyard.transform.position;
    //        this.transform.SetParent(Graveyard.transform);
    //        cardScale = this.transform.localScale;
    //        this.transform.localScale = new Vector3(cardScale.x, cardScale.y = 0.1f, cardScale.z);
    //        resources.enemyGold += (2 + resources.enemyYellowQuantity);

    //        levelLoader.cardsRemaining -= 1;
    //    }
        

    //    //We need to add graveyard system

    //}

    void ParentChecker()
    {
        //------------PlayerCards-----------
        foreach (Transform t in Graveyard.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in PlayerBrownTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in PlayerBlueTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in PlayerGreenTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in PlayerGreyTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in PlayerRedTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in PlayerYellowTown.transform)
        {
            t.gameObject.tag = "PlayerYellowDropped";
        }
        //foreach (Transform t in PlayerPurpleTown.transform)
        //{
        //    t.gameObject.tag = "Blocked";
        //}

        //-----------EnemyCards---------
        foreach (Transform t in EnemyBrownTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in EnemyBlueTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in EnemyGreenTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in EnemyGreyTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in EnemyRedTown.transform)
        {
            t.gameObject.tag = "Blocked";
        }
        foreach (Transform t in EnemyYellowTown.transform)
        {
            t.gameObject.tag = "EnemyYellowDropped";
            //moveonclick.enabled = false;
        }
    }
}
