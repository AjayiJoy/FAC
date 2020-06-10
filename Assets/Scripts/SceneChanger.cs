using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void StartPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuit()
    {
        //Debug.Log("Game Quit");
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void OnCredit()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void HowTo()
    {
        SceneManager.LoadScene("HowtoScene");
    }
}
