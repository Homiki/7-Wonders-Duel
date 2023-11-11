using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public Material awers;
    public MoveOnClick moveOn;
    CardValues cardValues;
    CanBuyCollider canBuyCollider;
    public int quantityCards;
    Rigidbody rb;
    ChangingButton button;


    private void OnTriggerExit(Collider other)
    {
        quantityCards--;

        if (quantityCards <= 0)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = awers;
            moveOn.enabled = true;
            tag = "canBuy";
            Destroy(canBuyCollider);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cardValues = GetComponent<CardValues>();
        quantityCards = 2;
        moveOn = GetComponent<MoveOnClick>();
        canBuyCollider = GetComponent<CanBuyCollider>();
        moveOn.enabled = false;
        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
        //rb = GameObject.FindGameObjectWithTag("Purple").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (button.isShopOpened == true)
        {
            moveOn.enabled = false;
        }
    }
}
