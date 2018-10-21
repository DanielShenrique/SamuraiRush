using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonAniation : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    }
   public void Transiçao()
    {
        if (GameObject.FindGameObjectWithTag("Play"))
        {
            StartCoroutine(AnimationTrasitorStart());
        }
    }
    public void Quit()
    {
        if (GameObject.FindGameObjectWithTag("Exit"))
        {
            StartCoroutine(QuitAimation());
        }
    }

    public IEnumerator AnimationTrasitorStart()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
        StopCoroutine(AnimationTrasitorStart());
    }

    public IEnumerator QuitAimation()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
        Application.Quit();
        StopCoroutine(QuitAimation());
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
        PlayerPrefs.DeleteAll();
    }
}
