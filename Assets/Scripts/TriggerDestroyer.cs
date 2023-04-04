using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroyer : MonoBehaviour
{
    Vector3 move;

    void Start()
    {
        StartCoroutine(Waiter());
    }
    IEnumerator Waiter()
    {
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);

        //Moving triggers down by 5
        this.transform.localPosition = new Vector3(move.x, move.y, move.z = 5);

        //Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        
        //gameObject.SetActive(false);

        Destroy(gameObject);

        Debug.Log("Destroyed");

    }
}
