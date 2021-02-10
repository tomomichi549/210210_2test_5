using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class Timer : MonoBehaviour


{
    public GameManager gameManager;
    public MainManager mainManager;
    public MenuManager menuManager;


    public TextMeshProUGUI timerText;
    [Header("Time Values")]
    //[Range(0, 60)]
    public int seconds, minutes, hours;
    public Color fontColorRunning, fontColorStop;

    private float currentSeconds;
    private int timerDefault;
    public bool showMilliseconds;
    public Boolean isRunning, isPause, timeReady;
    public AudioSource timecountdown;
    public AudioClip timeS;
    // Start is called before the first frame update
    public void TimeStart()
    {
        
        seconds = menuManager.gameTime;
        isRunning = false;
        isPause = false;
        timerText.color = fontColorRunning;
        timerDefault = 0;
        timerDefault += (seconds + (minutes * 60) + (hours * 60 * 60));
        currentSeconds = timerDefault;
        timeReady = true;
        setTimeText();
    }

    // Update is called once per frame
    void Update()
{
        if (timeReady == false)
        {
            if (isPause == false)
            {
                if (isRunning)
                {
                    
                    if ((currentSeconds -= Time.deltaTime) <= 0)
                    {
                        isRunning = false;
                        isPause = true;
                        gameManager.FlagRorate = false;
                        setTimeTextLose();
                        if (gameManager.Win == true)
                        {
                            
                            gameManager.setWin();
                        }
                        else
                        {
                            
                            gameManager.setLose();
                        }
                    }
                    else
                    {
                        if ((int)currentSeconds == 5)
                        {
                            timecountdown.PlayOneShot(timeS);
                        }
                        if (gameManager.Win == true)
                        {
                            isRunning = false;
                            isPause = true;
                            gameManager.FlagRorate = false;
                            gameManager.setWin();
                        }
                        setTimeText();
                    }
                }
                else
                {
                    if (gameManager.Win == true)
                    {
                        isPause = true;
                        gameManager.setWin();
                        setTimeText();
                    }
                    else
                    {
                        isPause = true;
                        setTimeTextLose();
                        gameManager.setLose();
                    }
                }
            }
            else
            {
                setTimeText();
            }
        }
    }

    
   

    void setTimeText()
    {
        timerText.color = fontColorRunning;
        if (showMilliseconds)
            timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss\:fff");
        else
            timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss");

    }

    void setTimeTextLose()
    {
        timerText.color = fontColorStop;
        if (showMilliseconds)
            timerText.text = "00:00:00:000";

        else
            timerText.text = "00:00:00";
    }
    
}
