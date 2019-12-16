using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonAnimation : MonoBehaviour {


    Animator animator;

    [SerializeField]
    private GameObject painelToSkin;

    void Start () {
        animator = GetComponent<Animator>();
	}
	
    public void Transiçao()
    {
        if (GameObject.FindGameObjectWithTag("Play"))
        {
            StartCoroutine(Animation());
            SceneManager.LoadScene(1);
            StopCoroutine(Animation());
        }
    }
    public void Quit()
    {
        if (GameObject.FindGameObjectWithTag("Exit"))
        {
            StartCoroutine(Animation());
            Application.Quit();
            StopCoroutine(Animation());
        }
    }

    public void GetSkin()
    {
        if (GameObject.FindGameObjectWithTag("GetSkin"))
        {
            painelToSkin.SetActive(true);
        }
    }

    public IEnumerator Animation()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
    }

    public void RestartBoton()
    {
      if(GetComponent<ActPlayer>() == null)
      {
            SceneManager.LoadScene(1);
      }
    }

    public void ClearHighScore()
    {
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
