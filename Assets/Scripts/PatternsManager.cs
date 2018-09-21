using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternsManager : MonoBehaviour {


    public bool desaparece = false;
    public float speed;
    public bool canDestroy;

    void Start()
    {
        foreach (Transform child in transform)
        {

            int randomChild = Random.Range(1, 3);

;
            if (randomChild == 3)
            {
                child.GetComponent<PatternsManager>().canDestroy = true;
                Debug.Log(child.GetComponent<PatternsManager>().canDestroy = true);
            }
            //child[randomChild - 1].GetComponent<PatternsManager>().canDestroy = true;

            //Debug.Log(child[randomChild].GetComponent<PatternsManager>().canDestroy);

            break;
        }

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
    IEnumerator Patterns()
    {
        yield return new WaitForSeconds(4);
        desaparece = true;
        StopCoroutine(Patterns());
    }
}
