using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingButton : MonoBehaviour
{
    public Animator shopTransition;
    public Animator playerPanelTransition;
    public Animator enemyPanelTransition;

    public Sprite playerButtonSprite;
    public Sprite enemyButtonSprite;
    public Button button;
    public GameObject playerPanel;
    public GameObject enemyPanel;

    public GameObject shop;

    public FreeItemsBuy karawanserajFreeItems;
    public FreeItemsBuy forumFreeItems;

    public bool isYourTurn;
    public bool isEnemyTurn;

    public bool isShopOpened;

    Reso resources;
    public int boughtGlina;
    public int boughtDrewno;
    public int boughtKamien;
    public int boughtPapirus;
    public int boughtSzklo;

    void Start()
    {
        isYourTurn = true;
        isEnemyTurn = false;


        playerPanel = GameObject.FindGameObjectWithTag("PlayerResources");
        enemyPanel = GameObject.FindGameObjectWithTag("EnemyResources");
        shop = GameObject.FindGameObjectWithTag("Shop");
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();


        isShopOpened = false;
    }
    private void Update()
    {

        if (isYourTurn == true && isEnemyTurn == false)
        {
            //playerPanel.SetActive(true);
            //enemyPanel.SetActive(false);
            playerPanelTransition.SetBool("IsPlayerPanelOpened", true);
            enemyPanelTransition.SetBool("IsEnemyPanelOpened", false);

        }
        else
        {
            //playerPanel.SetActive(false);
            //enemyPanel.SetActive(true);
            playerPanelTransition.SetBool("IsPlayerPanelOpened", false);
            enemyPanelTransition.SetBool("IsEnemyPanelOpened", true);

        }

        if(isShopOpened == false)
        {
            shopTransition.SetBool("IsShopOpened", false);
            //shop.SetActive(false);
        }
        else if(isShopOpened == true)
        {
            //shop.SetActive(true);
            shopTransition.SetBool("IsShopOpened", true);
        }
    }

    public void ChangeButtonImage()
    {
        //button.GetComponent<Image>().sprite = playerButtonSprite;
        //button.image.sprite = enemyButtonSprite;

        if (button.image.sprite == enemyButtonSprite)
        {
            button.image.sprite = playerButtonSprite;
            isYourTurn=true;
            isEnemyTurn = false;
        }else
        {
            button.image.sprite = enemyButtonSprite;
            isEnemyTurn = true;
            isYourTurn = false;
        }

        if(isYourTurn == true && isEnemyTurn == false)
        {
            resources.enemyGlina -= boughtGlina;
            resources.enemyWood -= boughtDrewno;
            resources.enemyStone -= boughtKamien;
            resources.enemyPapirus -= boughtPapirus;
            resources.enemyGlass -= boughtSzklo;

            boughtGlina = 0;
            boughtDrewno = 0;
            boughtKamien = 0;
            boughtPapirus = 0;
            boughtSzklo = 0;

            forumFreeItems.forumItemCounter = 1;
            karawanserajFreeItems.karawanserajItemCounter = 1;
        }
        else if (isYourTurn == false && isEnemyTurn == true)
        {
            resources.glina -= boughtGlina;
            resources.wood -= boughtDrewno;
            resources.stone -= boughtKamien;
            resources.papirus -= boughtPapirus;
            resources.glass -= boughtSzklo;

            boughtGlina = 0;
            boughtDrewno = 0;
            boughtKamien = 0;
            boughtPapirus = 0;
            boughtSzklo = 0;

            forumFreeItems.forumItemCounter = 1;
            karawanserajFreeItems.karawanserajItemCounter = 1;
        }
    }

    public void ShopOpening()
    {
        if (isShopOpened == false)
        {   
            isShopOpened = true;
        }
        else if (isShopOpened == true)
        {
            isShopOpened=false;
        }

    }
}
