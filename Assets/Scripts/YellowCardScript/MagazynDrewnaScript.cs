using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazynDrewnaScript : MonoBehaviour
{
    ChangingButton button;
    Reso resources;

    // Wood for one gold in shop
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
    }

    // Update is called once per frame
    void Update()
    {
        PriceDiscount();
    }

    void PriceDiscount()
    {
        if (CompareTag("PlayerYellowDropped") && button.isYourTurn == true)
        {
            resources.priceWood = 1;
            resources.drewnoTextPrice.text = 1.ToString();
        }
        else if(CompareTag("EnemyYellowDropped") && button.isEnemyTurn == true)
        {
            resources.priceWood = 1; 
            resources.drewnoTextPrice.text = 1.ToString();
        }
    }
}
