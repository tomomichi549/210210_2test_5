using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NotificationManager : MonoBehaviour



{

    public Animator animator;
    public MainManager mainManager;
    public Timer timer;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Open()
    {
        animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        
        animator.SetBool("IsOpen", false);
        timer.isPause = false;
        if (timer.timeReady == false)
        {
            gameManager.animatorTextWinLose.SetBool("isOpen", false);
        }
        


    }

    public void BtnYes() {
        Close();
        timer.isPause = true;
        mainManager.Back();
        if (gameManager.animatorTextWinLose.GetBool("isOpen"))
        {
            gameManager.animatorTextWinLose.SetBool("isOpen", false);
        }
        if (gameManager.animatorImageWIN.GetBool("IsOpen"))
        {
            gameManager.animatorImageWIN.SetBool("IsOpen", false);
        }
    }




}
