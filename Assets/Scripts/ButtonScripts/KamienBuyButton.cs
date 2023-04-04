using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KamienBuyButton : MonoBehaviour
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
        CantBuyKamien();
    }
    public void BuyKamien()
    {
        if (resources.gold >= resources.priceStone && changeButton.isYourTurn == true)
        {
            //Can buy
            resources.stone++;
            resources.gold -= resources.priceStone;
            changeButton.boughtKamien++;

        }
        else if (resources.enemyGold >= resources.priceStone && changeButton.isEnemyTurn == true)
        {
            //Enemy can buy
            resources.enemyStone++;
            resources.enemyGold -= resources.priceStone;
            changeButton.boughtKamien++;
        }
    }
    public void CantBuyKamien()
    {
        if (resources.gold <= resources.priceStone && changeButton.isYourTurn == true)
        {
            //Cant buy
            buyButton.interactable = false;
        }
        else if (resources.enemyGold <= resources.priceStone && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = false;
        }

        if (resources.gold >= resources.priceStone && changeButton.isYourTurn == true)
        {
            buyButton.interactable = true;
        }
        else if (resources.enemyGold >= resources.priceStone && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = true;
        }
    }
}
