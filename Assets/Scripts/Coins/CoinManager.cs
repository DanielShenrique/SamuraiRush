using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {


    public bool desaparece = false;
    private float speed;
    public bool canDestroy;

    public int coin;

    private void Awake()
    { 

    }

    void Start()
    {
        coin = 0;

        speed = Random.Range(5f, 10f);

    }

    void Update()
    {
        StartCoroutine(Patterns());
        if (desaparece == true)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < Camera.main.transform.position.x - 22)
            {
                Destroy(gameObject);
            }
        }
    }

    public void GetCoin()
    {
        coin += 10;

        CoinOnMainMenu.coins = coin;
        Debug.Log(CoinOnMainMenu.coins);
        PlayerPrefs.SetInt("numCoins", CoinOnMainMenu.coins);

    }

    IEnumerator Patterns()
    {
        yield return new WaitForSeconds(4);
        desaparece = true;
        StopCoroutine(Patterns());
    }
}
