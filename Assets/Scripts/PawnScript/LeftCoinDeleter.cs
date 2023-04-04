using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCoinDeleter : MonoBehaviour
{
    public Reso resources;
    public int coins;

    void Start()
    {
        resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        resources.gold -= coins;
        Destroy(transform.parent.gameObject);
    }
}
