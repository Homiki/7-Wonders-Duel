using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardValues : MonoBehaviour
{
    public int glinaV;
    public int kamienV;
    public int glassV;
    public int papirusV;
    public int drewnoV;
    public int goldV;
    public int PZ;
    public int militaryV;

    public int cost;
    public int costGlina;
    public int costGlass;
    public int costKamien;
    public int costDrewno;
    public int costPapirus;

    public MoveOnClick moveOnClick;
    public Reso resources;
    public Rigidbody rb;
    public BoxCollider bc;
    public FlipCard flip;

    public Material rewers;

    public ChangingButton button;

    bool canBuy;

    void Start()
    {
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
        moveOnClick = GetComponent<MoveOnClick>();
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        flip = GetComponent<FlipCard>();
        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        //this.tag = "cantBuy";

    }

    void Update()
    {

        CanBuyChecker();

        //if (CompareTag("Dropped"))
        //{
        //    resources.glina += glinaV;
        //    resources.gold += goldV;
        //    resources.stone += kamienV;
        //    resources.wood += drewnoV;
        //    resources.glass += glassV;
        //    resources.papirus += papirusV;
        //    resources.PZ += PZ;

        //    resources.gold -= cost;

        //    this.gameObject.tag = "Done";
        //}
        if (CompareTag("Blocked"))
        {
            moveOnClick.enabled = false;
        }
        if (CompareTag("PlayerYellowDropped"))
        {
            moveOnClick.enabled = false;
        }
        if (CompareTag("EnemyYellowDropped"))
        {
            moveOnClick.enabled = false;
        }


        //if (CompareTag("canBuy"))
        //{
        //    moveOnClick.enabled = true;
        //}
        //else
        //if (CompareTag("cantBuy"))
        //{
        //    moveOnClick.enabled = false;
        //}
        //    this.gameObject.GetComponent<MoveOnClick>().enabled = true;


        //---------------------------------------------------------------------

        if (CompareTag("Done"))
        {
            moveOnClick.enabled = false;
            //bc.enabled = true;
            //rb.useGravity = true;
        }
        //---------------------------------------------------------------------

        //if(resources.glina <= costGlina)
        //{
        //    moveOnClick.enabled = false; //dopóki nie wymyœle lepszego rozwi¹zania to bêdzie tak 
        //    rb.useGravity = false; // lepsze rozwiazanie = bez uzycia boxcollider i rigidbody
        //    bc.enabled = false;
        //}
        //else
        //{
        //    moveOnClick.enabled = true;
        //    bc.enabled = true;
        //    rb.useGravity = true;
        //}

        //if (resources.wood <= costDrewno)
        //{
        //    moveOnClick.enabled = false; //dopóki nie wymyœle lepszego rozwi¹zania to bêdzie tak 
        //    rb.useGravity = false; // lepsze rozwiazanie = bez uzycia boxcollider i rigidbody
        //    bc.enabled = false;
        //}
        //else
        //{
        //    moveOnClick.enabled = true;
        //    bc.enabled = true;
        //    rb.useGravity = true;
        //}

        //if (resources.glass <= costGlass)
        //{
        //    moveOnClick.enabled = false; //dopóki nie wymyœle lepszego rozwi¹zania to bêdzie tak 
        //    rb.useGravity = false; // lepsze rozwiazanie = bez uzycia boxcollider i rigidbody
        //    bc.enabled = false;
        //}
        //else
        //{
        //    moveOnClick.enabled = true;
        //    bc.enabled = true;
        //    rb.useGravity = true;
        //}

        //if (resources.stone <= costKamien)
        //{
        //    moveOnClick.enabled = false; //dopóki nie wymyœle lepszego rozwi¹zania to bêdzie tak 
        //    rb.useGravity = false; // lepsze rozwiazanie = bez uzycia boxcollider i rigidbody
        //    bc.enabled = false;
        //}
        //else
        //{
        //    moveOnClick.enabled = true;
        //    bc.enabled = true;
        //    rb.useGravity = true;
        //}

        //if (resources.papirus <= costPapirus)
        //{
        //    moveOnClick.enabled = false; //dopóki nie wymyœle lepszego rozwi¹zania to bêdzie tak 
        //    rb.useGravity = false; // lepsze rozwiazanie = bez uzycia boxcollider i rigidbody
        //    bc.enabled = false;
        //}
        //else
        //{
        //    moveOnClick.enabled = true;
        //    bc.enabled = true;
        //    rb.useGravity = true;
        //}

    }

    public void CanBuyChecker()
    {
        //--------------Blocking player to buy card if there is no gold------------------
        if (resources.gold >= cost && button.isYourTurn == true && button.isEnemyTurn == false)
        {
            moveOnClick.enabled = true;
            //canBuy = false;

        }
        else if (resources.gold < cost && button.isYourTurn == true && button.isEnemyTurn == false)
        {
            moveOnClick.enabled = false;
        }
        else if (resources.enemyGold >= cost && button.isYourTurn == false && button.isEnemyTurn == true)
        {
            moveOnClick.enabled = true;
            //canBuy = false;

        }
        else if (resources.enemyGold < cost && button.isYourTurn == false && button.isEnemyTurn == true)
        {
            moveOnClick.enabled = false;
        }

        //--------------Blocking Enemy to buy card if there is no gold------------------
    }

}
