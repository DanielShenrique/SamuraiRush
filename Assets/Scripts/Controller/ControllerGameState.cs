using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGameState : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private GameObject menuScored;
    [SerializeField]
    private GameObject highScored;
    [SerializeField]
    private GameObject restart;
    [SerializeField]
    private GameObject clearHighscore;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(player == null)
        {
            menuScored.SetActive(true);
            highScored.SetActive(true);
            restart.SetActive(true);
            clearHighscore.SetActive(true);
        }
    }
}
