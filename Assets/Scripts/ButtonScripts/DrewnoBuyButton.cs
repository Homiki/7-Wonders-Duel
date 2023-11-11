using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrewnoBuyButton : MonoBehaviour
{
    Button buyButton;
    public Reso resources;
    public ChangingButton changeButton;


    // Start is called before the first frame update
    void Start()
    {
        buyButton = this.gameObject.GetComponent<Button>();
        changeButton = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
    }

    // Update is called once per frame
    void Update()
    {
        CantBuyDrewno();
    }

    public void BuyDrewno()
    {
        if (resources.gold >= resources.priceWood && changeButton.isYourTurn == true)
        {
            //Can buy
            resources.wood++;
            resources.gold -= resources.priceWood;
            changeButton.boughtDrewno++;

        }
        else if (resources.enemyGold >= resources.priceWood && changeButton.isEnemyTurn == true)
        {
            //Enemy can buy
            resources.enemyWood++;
            resources.enemyGold -= resources.priceWood;
            changeButton.boughtDrewno++;
        }
    }
    public void CantBuyDrewno()
    {
        if (resources.gold <= resources.priceWood && changeButton.isYourTurn == true)
        {
            //Cant buy
            buyButton.interactable = false;
        }
        else if (resources.enemyGold <= resources.priceWood && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = false;
        }

        if (resources.gold >= resources.priceWood && changeButton.isYourTurn == true)
        {
            buyButton.interactable = true;
        }
        else if (resources.enemyGold >= resources.priceWood && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = true;
        }
    }
}
