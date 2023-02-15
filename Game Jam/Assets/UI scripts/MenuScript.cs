using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class MenuScript : MonoBehaviour
{

    public TMP_Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    [SerializeField] GameObject winScreen;

    [SerializeField] private AudioClip PostMouse;
    [SerializeField] private AudioSource musicPlayer;

    public void playgame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    void Update()
    {
        UpdateTimerUI();
    }

    public void musicChanger()
    {
        musicPlayer.clip = PostMouse;
        musicPlayer.Play();
        PlayerPrefs.SetInt("Mouse", 1);
    }
    public void quitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Mouse") == 1)
        {
            musicChanger();
        }
    }

    public void ReturnTMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");
    }

    public void retryScene()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void UpdateTimerUI()
    {
        try
        {
            //set timer UI
            secondsCount += Time.deltaTime;
            timerText.text = minuteCount + "m:" + (int)secondsCount + "s";
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }
            else if (minuteCount >= 60)
            {
                minuteCount = 0;
            }
            if (minuteCount > 15)
            {
                Time.timeScale = 0;
                winScreen.SetActive(true);
                PlayerPrefs.SetInt("hasWon", 1);
            }
        }
        catch
        {

        }
    }




}
