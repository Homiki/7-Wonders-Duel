using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingButton : MonoBehaviour
{
    public Sprite playerButtonSprite;
    public Sprite enemyButtonSprite;
    public Button button;
    public GameObject playerPanel;
    public GameObject enemyPanel;

    public GameObject shop;

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
            playerPanel.SetActive(true);
            enemyPanel.SetActive(false);
        }
        else
        {
            playerPanel.SetActive(false);
            enemyPanel.SetActive(true);
        }

        if(isShopOpened == false)
        {
            shop.SetActive(false);
            
        }else if(isShopOpened == true)
        {
            shop.SetActive(true);
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
