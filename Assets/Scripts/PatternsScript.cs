using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternsScript : MonoBehaviour {


    public GameObject[] Patter;
    float randomy;
    Vector2 Qualquerlocal;
    public float SpawnRate;
    float NextSpawn;
   
    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update () {
        if(Time.time > NextSpawn)
        {
            int r = Random.Range(1, 4);

            NextSpawn = Time.time + SpawnRate;
            randomy = Random.Range(33.7f, 14.9f);
            Qualquerlocal = new Vector2(randomy, transform.position.y);

            Instantiate(Patter[r -1], Qualquerlocal, Quaternion.identity);
        }
	}
    
}
