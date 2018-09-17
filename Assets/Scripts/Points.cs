using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    /// <summary>
    /// Pontos, so atualizar, mais tarde usar JSON ou Player.Prefs
    /// </summary>

    public int num;

    public Text text;

    private GameObject player;
    private GameObject ground;
    private GameObject background;

    public int Num { get { return num; } set { num = value; } }



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");
        background = GameObject.FindGameObjectWithTag("Background");
    }

    void Update()
    {
        /// teste
        num++;
        text.text = num.ToString();

		SavePoints();
    }

	void SavePoints()
	{
		if(player == null) {
			PlayerPrefs.SetInt("score", num);
			Debug.Log("salvou");
		}
	}
}
