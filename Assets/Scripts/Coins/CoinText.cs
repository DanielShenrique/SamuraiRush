using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{

    private Text text;
    [SerializeField]
    private CoinManager cM;

    private void Start()
    {
        text = GetComponent<Text>();
    }


    private void Update()
    {
        text.text = cM.GetComponent<CoinManager>().coin.ToString();
    }
}
