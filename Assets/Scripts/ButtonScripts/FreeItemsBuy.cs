using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeItemsBuy : MonoBehaviour
{
    ChangingButton button;
    Reso resources;


    public int karawanserajItemCounter = 1;
    public int forumItemCounter = 1;

    public Button glinaItemBuyButton;
    public Button woodItemBuyButton;
    public Button stoneItemBuyButton;
    public Button papirusItemBuyButton;
    public Button glassItemBuyButton;


    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
    }

    // Update is called once per frame
    void Update()
    {
        if (forumItemCounter == 0)
        {
            papirusItemBuyButton.interactable = false;
            glassItemBuyButton.interactable = false;
        }
        else if (forumItemCounter == 1)
        {
            papirusItemBuyButton.interactable = true;
            glassItemBuyButton.interactable = true;
        }

        if (karawanserajItemCounter == 0)
        {
            glinaItemBuyButton.interactable = false;
            woodItemBuyButton.interactable = false;
            stoneItemBuyButton.interactable = false;
        }
        else if (karawanserajItemCounter == 1)
        {
            glinaItemBuyButton.interactable = true;
            woodItemBuyButton.interactable = true;
            stoneItemBuyButton.interactable = true;
        }
    }

    public void GlinaChoosen()
    {
        if (button.isYourTurn == true && karawanserajItemCounter > 0)
        {
            //Can buy
            karawanserajItemCounter--;
            resources.glina++;
            button.boughtGlina++;
        }
        else if (button.isEnemyTurn == true && karawanserajItemCounter > 0)
        {
            //Enemy can buy
            karawanserajItemCounter--;
            resources.enemyGlina++;
            button.boughtGlina++;
        }

        if (karawanserajItemCounter <= 0)
        {
            glinaItemBuyButton.interactable = false;
        }
        else if (karawanserajItemCounter == 1)
        {
            glinaItemBuyButton.interactable = true;
        }
    }

    public void WoodChoosen()
    {
        if (button.isYourTurn == true && karawanserajItemCounter > 0)
        {
            //Can buy
            karawanserajItemCounter--;
            resources.wood++;
            button.boughtDrewno++;
        }
        else if (button.isEnemyTurn == true && karawanserajItemCounter > 0)
        {
            //Enemy can buy
            karawanserajItemCounter--;
            resources.enemyWood++;
            button.boughtDrewno++;
        }

        if (karawanserajItemCounter <= 0)
        {
            woodItemBuyButton.interactable = false;
        }
        else if (karawanserajItemCounter == 1)
        {
            woodItemBuyButton.interactable = true;
        }
    }

    public void StoneChoosen()
    {
        if (button.isYourTurn == true && karawanserajItemCounter > 0)
        {
            //Can buy
            karawanserajItemCounter--;
            resources.stone++;
            button.boughtKamien++;
        }
        else if (button.isEnemyTurn == true && karawanserajItemCounter > 0)
        {
            //Enemy can buy
            karawanserajItemCounter--;
            resources.enemyStone++;
            button.boughtKamien++;
        }

        if (karawanserajItemCounter <= 0)
        {
            stoneItemBuyButton.interactable = false;
        }
        else if (karawanserajItemCounter == 1)
        {
            stoneItemBuyButton.interactable = true;
        }
    }

    public void PapirusChoosen()
    {
        if (button.isYourTurn == true && forumItemCounter > 0)
        {
            //Can buy
            forumItemCounter--;
            resources.papirus++;
            button.boughtPapirus++;
        }
        else if (button.isEnemyTurn == true && forumItemCounter > 0)
        {
            //Enemy can buy
            forumItemCounter--;
            resources.enemyPapirus++;
            button.boughtPapirus++;
        }

        if (forumItemCounter <= 0)
        {
            papirusItemBuyButton.interactable = false;
        }
        else if (forumItemCounter == 1)
        {
            papirusItemBuyButton.interactable = true;
        }
    }

    public void GlassChoosen()
    {
        if (button.isYourTurn == true && forumItemCounter > 0)
        {
            //Can buy
            forumItemCounter--;
            resources.glass++;
            button.boughtSzklo++;
        }
        else if (button.isEnemyTurn == true && forumItemCounter > 0)
        {
            //Enemy can buy
            forumItemCounter--;
            resources.enemyGlass++;
            button.boughtSzklo++;
        }

        if (forumItemCounter <= 0)
        {
            glassItemBuyButton.interactable = false;
        }
        else if (forumItemCounter == 1)
        {
            glassItemBuyButton.interactable = true;
        }
    }
}
