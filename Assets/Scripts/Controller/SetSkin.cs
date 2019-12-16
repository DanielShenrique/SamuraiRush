using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkin : MonoBehaviour
{
    [SerializeField]
    private GameObject painelSkin;


    public void ClickInSkin()
    {
        if (gameObject.name.Equals("Skin_1"))
        {
            PlayerPos.characterSelect = 0;
            Debug.Log(PlayerPos.characterSelect);
            PlayerPrefs.SetInt("selectplayer", PlayerPos.characterSelect);
        }
        else
        {
            if (gameObject.name.Equals("Skin_2"))
            {
                PlayerPos.characterSelect = 1;
                Debug.Log(PlayerPos.characterSelect);
                PlayerPrefs.SetInt("selectplayer", PlayerPos.characterSelect);
            }
        }
    }

    public void QuitPainelSkin()
    {
        painelSkin.SetActive(false);
    }
}
