using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    public Reso resources;

    int oldVal;
    Vector3 pawnPos;

    // Start is called before the first frame update
    void Start()
    {
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
        oldVal = resources.militaryToken;
        pawnPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (resources.militaryToken > oldVal)
        {
            //przesuwa sie w prawo o x = -2
            pawnPos.x -= 1.9f;
            transform.position = pawnPos;
            Debug.Log("idzie w prawo");
            oldVal = resources.militaryToken;
        }
        else if (resources.militaryToken < oldVal)
        {
            //przesuwa siê w lewo o x = 1.9
            pawnPos.x += 1.9f;
            transform.position = pawnPos;
            Debug.Log("idzie w lewo");
            oldVal = resources.militaryToken;
        }
    }
}
