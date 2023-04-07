using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    Reso resources;

    public GameObject freeItemShop;

    public Animator transition;

    public float transitionTime = 1f;

    public int cardsRemaining;

    void Start()
    {
        //resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Reso>();
        cardsRemaining = 20;
        freeItemShop = GameObject.Find("FreeItems");
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
        freeItemShop.SetActive(true);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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
