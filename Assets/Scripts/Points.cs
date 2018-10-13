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

    public int score = 0;
    public int highScore = 0;
    string highScoreKey = "Points";
    public Text SCORE;

    private GameObject player;
    private GameObject ground;
    private GameObject background;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");
        background = GameObject.FindGameObjectWithTag("Background");
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    void Update()
    {
        /// teste
        SCORE.text = " " + highScore.ToString();
        num++;
        text.text = num.ToString();
        SavePoints();
    }
    void OnDisable()
    {
        //If our scoree is greter than highscore, set new higscore and save.

    }
    void SavePoints()
    {
        if (player == null)
        {
            num--;
            if (num > highScore)
            {
                PlayerPrefs.SetInt(highScoreKey, num);
                PlayerPrefs.Save();
            }
        }
    }
}
