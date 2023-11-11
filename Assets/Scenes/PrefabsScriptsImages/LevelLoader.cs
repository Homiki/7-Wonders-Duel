using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    Reso resources;

    GameObject freeItemShop;
    GameObject freeGlina;
    GameObject freeDrewno;
    GameObject freeKamien;
    GameObject freePapirus;
    GameObject freeSzklo;

    public Animator transition;

    public float transitionTime = 1f;

    public int cardsRemaining;

    void Start()
    {
        //resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
        cardsRemaining = 20;
        freeGlina = GameObject.Find("FreeGlina");
        freeDrewno = GameObject.Find("FreeDrewno");
        freeKamien = GameObject.Find("FreeKamien");
        freePapirus = GameObject.Find("FreePapirus");
        freeSzklo = GameObject.Find("FreeSzklo");
        freeItemShop = GameObject.Find("FreeItems");
       
        //freeItemShop.SetActive(false);
        //freeGlina.SetActive(false);
        //freeDrewno.SetActive(false);
        //freeKamien.SetActive(false);
        //freePapirus.SetActive(false);
        //freeSzklo.SetActive(false);
    }

    void Update()
    {
        if(cardsRemaining == 0)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        freeItemShop.SetActive(true);
        freeGlina.SetActive(true);
        freeDrewno.SetActive(true);
        freeKamien.SetActive(true);
        freePapirus.SetActive(true);
        freeSzklo.SetActive(true);
        //StartCoroutine(LoadLevel(SceneManager.LoadScene(2)));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //yield return new WaitForSeconds(transitionTime);



        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);


    }
}
