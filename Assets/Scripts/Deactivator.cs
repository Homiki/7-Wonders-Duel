using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    MoveOnClick m;

    private void Start()
    {
        m.GetComponent<MoveOnClick>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m.enabled = false;
    }
}
