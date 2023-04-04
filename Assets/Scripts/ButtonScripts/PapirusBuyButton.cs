using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PapirusBuyButton : MonoBehaviour
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
        CantBuyPapirus();
    }
    public void BuyPapirus()
    {
        if (resources.gold >= resources.pricePapirus && changeButton.isYourTurn == true)
        {
            //Can buy
            resources.papirus++;
            resources.gold -= resources.pricePapirus;
            changeButton.boughtPapirus++;

        }
        else if (resources.enemyGold >= resources.pricePapirus && changeButton.isEnemyTurn == true)
        {
            //Enemy can buy
            resources.enemyPapirus++;
            resources.enemyGold -= resources.pricePapirus;
            changeButton.boughtPapirus++;
        }
    }
    public void CantBuyPapirus()
    {
        if (resources.gold <= resources.pricePapirus && changeButton.isYourTurn == true)
        {
            //Cant buy
            buyButton.interactable = false;
        }
        else if (resources.enemyGold <= resources.pricePapirus && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = false;
        }

        if (resources.gold >= resources.pricePapirus && changeButton.isYourTurn == true)
        {
            buyButton.interactable = true;
        }
        else if (resources.enemyGold >= resources.pricePapirus && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = true;
        }
    }
}
