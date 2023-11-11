using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazynGlinyScript : MonoBehaviour
{
    ChangingButton button;
    Reso resources;

    // Clay for one gold in store
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
            resources.priceGlina = 1;
            resources.glinaTextPrice.text = 1.ToString();
        }
        else if (CompareTag("EnemyYellowDropped") && button.isEnemyTurn == true)
        {
            resources.priceGlina = 1;
            resources.glinaTextPrice.text = 1.ToString();
        }
    }
}
