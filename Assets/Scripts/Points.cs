using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    /// <summary>
    /// Pontos, so atualizar, mais tarde usar JSON ou Player.Prefs
    /// </summary>

    private int num;

    public Text text;

    public int Num
    {
        get
        {
            return num;
        }
        set
        {
            num = value;
        }

    }


    void Start()
    {

    }

    void Update()
    {
        /// teste
        num++;
        text.text = num.ToString();
        ///
    }
}
