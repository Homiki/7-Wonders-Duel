using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCoinDeleter : MonoBehaviour
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
        resources.enemyGold -= coins;
        Destroy(transform.parent.gameObject);
    }
}
