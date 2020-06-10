using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLasted; //how many seconds it takes before life deplets
    public int timeLast;        //time in integers
    public Text timeText;  // linked to the time text in canvas

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Time lasted: " + timeLasted;
    }

    // Update is called once per frame
    void Update()
    {
        timeLasted += Time.deltaTime;    /*Add one second every frame*/
        timeLast = (int)timeLasted; //convert the float time to int 
        timeText.text = "Time lasted: " + timeLast;
        
    }


    public void GameOver()
    {
       // Debug.Log("Entered the game over");
        SceneManager.LoadScene("HomeScene"); //call homescreen
    }

   
}
