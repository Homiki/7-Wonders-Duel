using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazynKamieniaScript : MonoBehaviour
{
    ChangingButton button;
    Reso resources;

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
            resources.priceStone = 1;
            resources.kamienTextPrice.text = 1.ToString();
        }
        else if (CompareTag("EnemyYellowDropped") && button.isEnemyTurn == true)
        {
            resources.priceStone = 1;
            resources.kamienTextPrice.text = 1.ToString();
        }
    }
}
