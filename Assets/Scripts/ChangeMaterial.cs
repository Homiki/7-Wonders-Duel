using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material rewers;

    //public FlipCard flipCard;

    public bool isTriggered = false;


    public void OnTriggerEnter(Collider other)
    {

            other.gameObject.GetComponent<MeshRenderer>().material = rewers;

            isTriggered = true;

    }

    void Start()
    {
        
    }
}
