using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPettern : MonoBehaviour {

    private bool canDestroy = false;

	// Use this for initialization
	void Start ()
    {
	    if(Random.Range(1, 10) < 3)
        {
            canDestroy = true;
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }

	}

    public bool GetCanDestroy()
    {
        return canDestroy;
    }
}
