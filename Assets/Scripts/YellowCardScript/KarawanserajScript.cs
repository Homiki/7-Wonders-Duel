using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KarawanserajScript : MonoBehaviour
{
    ChangingButton button;
    Reso resources;

    //public GameObject freeItemShop;

    GameObject freeGlina;
    GameObject freeDrewno;
    GameObject freeKamien;
    //GameObject freePapirus;
    //GameObject freeSzklo;


    // Free wood, glina and stone script
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();

        //freeItemShop = GameObject.Find("FreeItems");
        freeGlina = GameObject.Find("FreeGlina");
        freeDrewno = GameObject.Find("FreeDrewno");
        freeKamien = GameObject.Find("FreeKamien");
        //freePapirus = GameObject.Find("FreePapirus");
        //freeSzklo = GameObject.Find("FreeSzklo");

        
        freeGlina.SetActive(false);
        freeDrewno.SetActive(false);
        freeKamien.SetActive(false);
        //freeItemShop.SetActive(false);

        //freePapirus.SetActive(false);
        //freeSzklo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FreeItems();
    }

    void FreeItems()
    {
        if (CompareTag("PlayerYellowDropped"))
        {
            //freeItemShop.SetActive(true);

            freeGlina.SetActive(true);
            freeDrewno.SetActive(true);
            freeKamien.SetActive(true);

            //freePapirus.SetActive(false);
            //freeSzklo.SetActive(false);

            if(button.isEnemyTurn == true)
            {
                //freeItemShop.SetActive(false);

                freeGlina.SetActive(false);
                freeDrewno.SetActive(false);
                freeKamien.SetActive(false);

                //freePapirus.SetActive(false);
                //freeSzklo.SetActive(false);
            }
        }
        else if (CompareTag("EnemyYellowDropped"))
        {
            //freeItemShop.SetActive(true);

            freeGlina.SetActive(true);
            freeDrewno.SetActive(true);
            freeKamien.SetActive(true);

            //freePapirus.SetActive(false);
            //freeSzklo.SetActive(false);

            if (button.isYourTurn == true)
            {
                //freeItemShop.SetActive(false);

                freeGlina.SetActive(false);
                freeDrewno.SetActive(false);
                freeKamien.SetActive(false);

                //freePapirus.SetActive(false);
                //freeSzklo.SetActive(false);
            }
        }
    }
}
