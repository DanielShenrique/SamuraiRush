﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    /// <summary>
    /// Pontos, so atualizar, mais tarde usar JSON ou Player.Prefs
    /// </summary>

    public int num;

    public Text text;

    private GameObject actAnimator;
    private GameObject ground;
    private GameObject background;

    public int Num { get { return num; } set { num = value; } }


    void Start()
    {
        actAnimator = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");
        background = GameObject.FindGameObjectWithTag("Background");
    }

    void Update()
    {
        /// teste
        num++;
        text.text = num.ToString();

        if(num == 1000)
        {
            num *= 2;
        }
        ///


        ///teste da velocidade da animação
        if(num == 1000)
        {
            actAnimator.GetComponent<ActPlayer>().animator.speed = 1.01f;
           // ground.GetComponent<Scrolling_Parallax>().speed = 21f;
            //print(actAnimator.GetComponent<ActPlayer>().animator.speed);
        }
        if(num == 2000)
        {
            actAnimator.GetComponent<ActPlayer>().animator.speed = 1.015f;
            //ground.GetComponent<Scrolling_Parallax>().speed = 22f;
           // print(actAnimator.GetComponent<ActPlayer>().animator.speed);
        }
        if (num == 4000)
        {
            actAnimator.GetComponent<ActPlayer>().animator.speed = 1.02f;
            //ground.GetComponent<Scrolling_Parallax>().speed = 23f;
            //print(actAnimator.GetComponent<ActPlayer>().animator.speed);
        }
        if (num == 8000)
        {
            actAnimator.GetComponent<ActPlayer>().animator.speed = 1.025f;
           // print(actAnimator.GetComponent<ActPlayer>().animator.speed);
        }
        if (num == 10000)
        {
            actAnimator.GetComponent<ActPlayer>().animator.speed = 1.03f;
            //print(actAnimator.GetComponent<ActPlayer>().animator.speed);
        }
        ///
    }
}
