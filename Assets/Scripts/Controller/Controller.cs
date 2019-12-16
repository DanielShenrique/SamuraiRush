using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject[] sp;


    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

}
