using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

   public ActPlayer act;

    private GameObject player;

    private Vector2 position;

    //private Vector2 
	void Start () {

		player = GameObject.FindWithTag("Player");
    }
	
	void Update () {
        position = new Vector2(transform.position.x, transform.position.y);

        if (act.SwipeLeft)
        {
            position += Vector2.left * act.Speed;
            Debug.Log(position);
        }
        if (act.SwipeRight)
        {
            position += Vector2.right * act.Speed;
            Debug.Log(position);
        }


        player.GetComponent<Transform>().position = Vector2.MoveTowards(player.GetComponent<Transform>().position, position, act.Speed * Time.deltaTime);

        if (act.Tap)
        {
            Debug.Log("tap");
        }
    }
}
