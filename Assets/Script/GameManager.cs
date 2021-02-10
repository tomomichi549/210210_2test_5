using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public Timer timer;
    [SerializeField]
    int totalPic = 0;
    [SerializeField]
    int correctPic = 0;
    public Boolean Win;
    public Boolean FlagRorate;
    public GameObject 蛇パズル_背景;
    public PicScript[] picScripts;
    public GameObject[] a_k_s;
    public Animator animatorTextWinLose, animatorImageWIN;
    public Text TextWin_lose;
    public Button BtnStart, BtnReplay;

    public NotificationManager notificationManager;
    public AudioClip timeS;
    public AudioClip winS;
    public AudioClip loseS;
    public AudioSource GameS;
    public AudioSource MainS;

    // Start is called before the first frame update
    public void Start()
    {
        animatorImageWIN.SetBool("IsOpen", false);
        BtnStart.interactable = true;
        BtnReplay.interactable = false;
        PicNew();
        timer.TimeStart();
        Win = false;
        FlagRorate = false;
        totalPic = picScripts.Length;
        animatorTextWinLose.SetBool("isOpen", false);
        蛇パズル_背景.GetComponent<SpriteRenderer>().color = new Color32(205, 205, 205, 255);
        foreach (GameObject pic in a_k_s)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(202,193, 193, 125);

        }
        foreach (PicScript pic in picScripts)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(202,193, 193, 125);
        }
    }



    public void correctMove()
    {
        correctPic += 1;
        if (correctPic == totalPic)
        {
            Win = true;
        }
    }


    public void wrongMove()
    {
        correctPic -= 1;
    }

    public void PicNew()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        correctPic = 0;
        foreach (PicScript pic in picScripts)
        {
            pic.isPlaced = false;
            pic.New();   
        }
    }


    public void setWin()
    {
        MainS.volume = 0.001f;
        GameS.PlayOneShot(winS);
        TextWin_lose.text = "...勝利!";
        TextWin_lose.color = new Color32(198, 129, 22, 255);
        animatorTextWinLose.SetBool("isOpen", true);
        蛇パズル_背景.GetComponent<SpriteRenderer>().color = new Color32(82, 56, 27, 255);
        foreach (GameObject pic in a_k_s)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        }
        foreach (PicScript pic in picScripts)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        }
        animatorImageWIN.SetBool("IsOpen", true);
        
    }

    public void setLose()
    {
        MainS.volume = 0.001f;
        GameS.PlayOneShot(loseS);
        timer.timeReady = true;
        TextWin_lose.text = "...敗北!";
        TextWin_lose.color = new Color32(162, 11, 0, 255);
        animatorTextWinLose.SetBool("isOpen", true);
        蛇パズル_背景.GetComponent<SpriteRenderer>().color = new Color32(82, 56, 27, 255);
    }


    public void Replay()
    {
        MainS.volume = 0.266f;
        Start();
        GameS.Stop();
    }

    public void Back()
    {
       
        timer.isPause = true;
        notificationManager.Open();
    }

    public void　StartGame()
    {
        
        
        MainS.volume = 0.021f;
        timer.timeReady = false;
        FlagRorate = true;
        timer.isRunning = true;
        BtnStart.interactable = false;
        BtnReplay.interactable = true;
        foreach (PicScript pic in picScripts)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255 , 255);
        }
    }


    
}
