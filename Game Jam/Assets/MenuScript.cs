using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    public void playgame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }



}
