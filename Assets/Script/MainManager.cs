using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MainManager : MonoBehaviour 
{

    public Button BtnBack;
    public Button BtnNext;
    public Animator menu_Ani, game_Ani;
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


    public void Next()
    {
        gameManager.Start();
        menu_Ani.SetBool("IsOpen", false);
        game_Ani.SetBool("IsOpen", true);
    }

    public void Back()
    { 

        game_Ani.SetBool("IsOpen", false);
        menu_Ani.SetBool("IsOpen", true);
        
    }



}
