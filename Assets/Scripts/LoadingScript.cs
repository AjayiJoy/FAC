using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public float timeLasted;
    void Update()
    {
       timeLasted += Time.deltaTime;

        if(timeLasted >= 10.0f)
        {
            SceneManager.LoadScene("HomeScene");
        }
    }

   
}
