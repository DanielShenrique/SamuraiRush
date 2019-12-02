using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{


    /// <summary>
    /// Pontos, so atualizar, mais tarde usar JSON ou Player.Prefs
    /// </summary>

    public int num;
    public Text text;

    public int[] highScores = new int[5];
    public int[] highScoresOrdenada = new int[5];
    //public List<int> ighscored;  

    public int score = 0;
    public int highScore;
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

        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = PlayerPrefs.GetInt(highScoreKey + (i + 1).ToString(), 0);
            highScoresOrdenada[i] = PlayerPrefs.GetInt(highScoreKey + (i + 1).ToString(), -5);
        }

    }

    void Update()
    {
        if (player != null)
        {
            num++;
            text.text = num.ToString();
        }
        ApareceScore();

        //SavePoints();

    }
    void ApareceScore()
    {
        SCORE.text = " " + highScores[0].ToString();
    }

    public void SavePoints()
    {
        TradePoints();

        var maxpoints = 0;
        var index = 0;

        for (int a = 0; a < highScores.Length; a++)
        {
            for (int i = 0; i < highScores.Length; i++)
            {
                if (highScores[i] > maxpoints)
                {
                    maxpoints = highScores[i];
                    index = i;
                }
            }
            highScores[index] = 0;
            highScoresOrdenada[a] = maxpoints;
            PlayerPrefs.SetInt(highScoreKey + (a + 1).ToString(), highScoresOrdenada[a]);
            PlayerPrefs.Save();
            maxpoints = 0;
        }
        for (int a = 0; a < highScores.Length; a++)
        {
            highScores[a] = highScoresOrdenada[a];
        }
    }
         public void TradePoints()
         {
         var tradepoints = 99999999999999;
         var index = 0;

             for (int i = 0; i < highScores.Length; i++)
             {
                 if (highScores[i] < tradepoints)
                 {
                     tradepoints = highScores[i];
                     index = i;

                 }
             }
             highScores[index] = num;

         }
    }
 /*
 * Pegando uma array não ordenada
 * Transformando ela em uma array ordenada
 * Criando uma array ordenada e salvando 
 */

