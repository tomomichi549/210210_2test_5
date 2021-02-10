using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    public Text DialogueText;

    public Animator animator;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            endDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        }


    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    private void endDialouge()
    {
        animator.SetBool("IsOpen", false);
    }
}
