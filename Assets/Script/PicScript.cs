using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PicScript : MonoBehaviour
{
    // Start is called before the first frame update

    int[] rotations = { 0, 90, 180, 270 };

    public int[] correctRotation;

    int PossibleRots = 1;
    [SerializeField]
    public Boolean isPlaced = false;


    GameManager gameManager;



    public AudioClip soundRorate;
    public AudioSource puzzle;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
   





    private void OnMouseDown()
    {
        
        if (gameManager.FlagRorate == true)
        {
            clickOnSound();
            transform.Rotate(new Vector3(0, 0, 90));
            if (PossibleRots > 1)
            {
                if (((int)transform.eulerAngles.z == correctRotation[0]) || ((int)transform.eulerAngles.z == correctRotation[1]) && isPlaced == false)
                {
                    isPlaced = true;
                    gameManager.correctMove();
                }
                else if (isPlaced == true)
                {
                    isPlaced = false;
                    gameManager.wrongMove();
                }
            }
            else
            {
                if ((int)transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
                {
                    isPlaced = true;
                    gameManager.correctMove();
                }
                else if (isPlaced == true)
                {
                    isPlaced = false;
                    gameManager.wrongMove();
                }
            }
        }


    }
    public void New()

    {

        PossibleRots = correctRotation.Length;
        int rand = UnityEngine.Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (PossibleRots > 1)
        {
            if (((int)transform.eulerAngles.z == correctRotation[0]) || ((int)transform.eulerAngles.z == correctRotation[1]))
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
        else
        {
            if ((int)transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }

    }


    public void clickOnSound()
    {
        puzzle.PlayOneShot(soundRorate);
    }
}
