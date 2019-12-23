using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinOnMainMenu : MonoBehaviour
{
    public static int coins;

    private Text text;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("numCoins");
        text = GetComponent<Text>();
    }

    private void Start()
    {
        text.text = coins.ToString();
    }

}
