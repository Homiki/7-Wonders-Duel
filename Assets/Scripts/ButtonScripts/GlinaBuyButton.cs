using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlinaBuyButton : MonoBehaviour
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
        CantBuyGlina();
    }

    public void BuyGlina()
    {
        if(resources.gold >= resources.priceGlina && changeButton.isYourTurn == true)
        {
            //Can buy
            resources.glina++;
            resources.gold -= resources.priceGlina;
            changeButton.boughtGlina++;

        }else if(resources.enemyGold >= resources.priceGlina && changeButton.isEnemyTurn == true)
        {
            //Enemy can buy
            resources.enemyGlina++;
            resources.enemyGold -= resources.priceGlina;
            changeButton.boughtGlina++;
        }
    }
    public void CantBuyGlina()
    {
        if (resources.gold <= resources.priceGlina && changeButton.isYourTurn == true)
        {
            //Cant buy
            buyButton.interactable = false;
        }
        else if (resources.enemyGold <= resources.priceGlina && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = false;
        }

        if (resources.gold >= resources.priceGlina && changeButton.isYourTurn == true)
        {
            buyButton.interactable = true;
        }
        else if (resources.enemyGold >= resources.priceGlina && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = true;
        }
    }
}
