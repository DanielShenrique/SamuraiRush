using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Highscoreshow : MonoBehaviour {

    public Text SCORE;
    public GameObject Panel;
     void Update()
    {
        if (Panel == true)
        {
            SCORE.text = " " + GetComponent<Points>().highScores[0].ToString();
        }
    }

}
