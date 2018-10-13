using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternsScript : MonoBehaviour {


    public GameObject[] Patter;
    float randomy;
    Vector2 qualquerLugar;
    public float spawnRate;
    float nextSpawn;
   
    void Update () {
        if(Time.time > nextSpawn)
        {
            int r = Random.Range(1, 4);

            nextSpawn = Time.time + spawnRate;
            randomy = Random.Range(33.7f, 14.9f);
            qualquerLugar = new Vector2(randomy, transform.position.y);

            Instantiate(Patter[r -1], qualquerLugar, Quaternion.identity);
        }
	}
    
}
