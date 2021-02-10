using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Button btnYes, btnNo, btn_ten_mili, btn_twenty_mili, btn_thirty_mili, btnNext;
    // Start is called before the first frame update
    public int gameTime;
    void Start()
    {
        btnNext.interactable = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Btn_ten_mili()
    {
        gameTime = 10;
        btnNext.interactable = true;
        btn_ten_mili.interactable = false;
        btn_twenty_mili.interactable = true;
        btn_thirty_mili.interactable = true;
    }


    public void Btn_twenty_mili()
    {
        gameTime = 20;
        btnNext.interactable = true;
        btn_ten_mili.interactable = true;
        btn_twenty_mili.interactable = false;
        btn_thirty_mili.interactable = true;
    }


    public void Btn_thirty_mili()
    {
        gameTime = 30;
        btnNext.interactable = true;
        btn_ten_mili.interactable = true;
        btn_twenty_mili.interactable = true;
        btn_thirty_mili.interactable = false;
    }


    



}
