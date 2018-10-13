using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] powerUps;

    float random_x;
    float random_y;
    public float spwanRate;
    float nextSpawn;

    Vector2 place;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            int r = Random.Range(1, 2);

            nextSpawn = Time.time + spwanRate;
            random_x = Random.Range(33.7f, 14.9f);
            random_y = Random.Range(-2.6f, 2.2f);
            place = new Vector2(random_x, random_y);

            Instantiate(powerUps[r - 1], place, Quaternion.identity);
        }
    }

}
