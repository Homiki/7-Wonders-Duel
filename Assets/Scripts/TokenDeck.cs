using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenDeck : MonoBehaviour
{
    public GameObject[] tokenNeeded;
    public GameObject[] emptyToken;

    public List<GameObject> tokens;

    public int random;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            do
            {
                random = UnityEngine.Random.Range(0, tokenNeeded.Length);
                Debug.Log(random);
            } while (tokens.Contains(tokenNeeded[random]));
            tokens.Add(tokenNeeded[random]);
        }
    }
}
