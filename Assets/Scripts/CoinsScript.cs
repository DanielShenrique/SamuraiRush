using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {

    [SerializeField]
    private GameObject coin;

    float randomy_x;
    float randomy_y;
    Vector2 place;
    public float spwanRate;
    float nextSpawn;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spwanRate;
            randomy_x = Random.Range(33.7f, 14.9f);
            randomy_y = Random.Range(-2.6f, 2.2f);
            place = new Vector2(randomy_x, randomy_y);

            Instantiate(coin, place, Quaternion.identity);
        }
    }
}
