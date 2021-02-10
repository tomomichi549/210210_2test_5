using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{


    public AudioSource button;
    public AudioClip ClickS; 
    // Start is called before the first frame update
    public void click()
    {
        button.PlayOneShot(ClickS);
    }
}
