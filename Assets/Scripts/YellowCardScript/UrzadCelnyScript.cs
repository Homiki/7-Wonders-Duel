using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrzadCelnyScript : MonoBehaviour
{
    //[SerializeField] private ChangingButton button;
    ChangingButton button;
    Reso resources;

    // Glass and Papirus for one gold in shop
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
    }


    void Update()
    {
        PriceDiscount();
    }

    void PriceDiscount()
    {
        if (CompareTag("PlayerYellowDropped") && button.isYourTurn == true)
        {
            resources.priceGlass = 1;
            resources.pricePapirus = 1;
            resources.szkloTextPrice.text = 1.ToString();
            resources.papirusTextPrice.text = 1.ToString();
        }
        else if (CompareTag("EnemyYellowDropped") && button.isEnemyTurn == true)
        {
            resources.priceGlass = 1;
            resources.pricePapirus = 1;
            resources.szkloTextPrice.text = 1.ToString();
            resources.papirusTextPrice.text = 1.ToString();
        }
    }
}
