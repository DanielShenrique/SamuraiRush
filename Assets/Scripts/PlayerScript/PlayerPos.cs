using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    public static int characterSelect;

    [SerializeField]
    private GameObject[] players;

    private void Awake()
    {
        characterSelect = PlayerPrefs.GetInt("selectplayer");

        Debug.Log(characterSelect);

        Instantiate(players[characterSelect], this.transform.position, Quaternion.identity);      
    }
}
