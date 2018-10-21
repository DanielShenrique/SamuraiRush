using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternsManager : MonoBehaviour {


    public bool desaparece = false;
    public float speed;
    private float plusSpeed;
    public bool canDestroy;

    private Points p;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();

        if(p.num >= 2000 && p.num < 4000)
        {
            plusSpeed = 2f;
            speed = speed + plusSpeed;
        }
        if (p.num >= 4000 && p.num < 6000)
        {
            plusSpeed = 4f;
            speed = speed + plusSpeed;
        }
        if (p.num >= 6000 & p.num < 8000)
        {
            plusSpeed = 6f;
            speed = speed + plusSpeed;
        }
        if (p.num >= 8000)
        {
            plusSpeed = 8f;
            speed = speed + plusSpeed;
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

        //print(speed);
    }
    IEnumerator Patterns()
    {
        yield return new WaitForSeconds(4);
        desaparece = true;
        StopCoroutine(Patterns());
    }
}
