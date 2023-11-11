using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeItemShopController : MonoBehaviour
{

    // Free items controller

    void Start()
    {
        StartCoroutine(Deactivator());
        
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    gameObject.SetActive(false);
        //}

        //if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    gameObject.SetActive(true);
        //}
    }

    IEnumerator Deactivator()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
