using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBuyCollider : MonoBehaviour
{
    public MoveOnClick moveOnClick;
    BoxCollider box;
    public void OnTriggerStay(Collider other)
    {

        //this.gameObject.tag = "cantbuy";
        //moveOnClick.tag = "cantbuy";
        other.gameObject.tag = "cantBuy";
        //other.gameObject.GetComponent<MoveOnClick>().enabled = false;

    }

    private void Update()
    {
        box = GetComponent<BoxCollider>();
        //moveOnClick.GetComponent<MoveOnClick>();
        moveOnClick = GameObject.FindGameObjectWithTag("cantBuy").GetComponent<MoveOnClick>();
        //moveOnClick.tag = "cantBuy";
    }
}
