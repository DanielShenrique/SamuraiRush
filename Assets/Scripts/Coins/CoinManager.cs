using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {


    public bool desaparece = false;
    private float speed;
    public bool canDestroy;

    public int coinVal;

    private Points p;

    private void Awake()
    {
        p = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
    }

    void Start()
    {
        coinVal = 1;

        speed = Random.Range(5f, 10f);

        ValueCoin();
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

    public void ValueCoin()
    {
        if (p.num >= 2000 && p.num < 4000)
        {
            coinVal += coinVal;
        }
        if (p.num >= 4000 && p.num < 6000)
        {
            coinVal += coinVal;
        }
        if (p.num >= 6000 & p.num < 8000)
        {
            coinVal += coinVal;
        }
    }

    IEnumerator Patterns()
    {
        yield return new WaitForSeconds(4);
        desaparece = true;
        StopCoroutine(Patterns());
    }
}
