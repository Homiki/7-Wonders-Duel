using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SzkloBuyButton : MonoBehaviour
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
        CantBuySzklo();
    }

    public void BuySzklo()
    {
        if (resources.gold >= resources.priceGlass && changeButton.isYourTurn == true)
        {
            //Can buy
            resources.glass++;
            resources.gold -= resources.priceGlass;
            changeButton.boughtSzklo++;
        }
        else if (resources.enemyGold >= resources.priceGlass && changeButton.isEnemyTurn == true)
        {
            //Enemy can buy
            resources.enemyGlass++;
            resources.enemyGold -= resources.priceGlass;
            changeButton.boughtSzklo++;
        }
    }
    public void CantBuySzklo()
    {
        if (resources.gold <= resources.priceGlass && changeButton.isYourTurn == true)
        {
            //Cant buy
            buyButton.interactable = false;
        }
        else if (resources.enemyGold <= resources.priceGlass && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = false;
        }

        if (resources.gold >= resources.priceGlass && changeButton.isYourTurn == true)
        {
            buyButton.interactable = true;
        }
        else if (resources.enemyGold >= resources.priceGlass && changeButton.isEnemyTurn == true)
        {
            buyButton.interactable = true;
        }
    }
}
