using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public Animator anim;

    public GameObject image;
    public GameObject mainChar;
    public GameObject nextChar;

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(Type());
    }
    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
    public void NextSentence()
    {
        //anim.SetTrigger("Change");
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            
            continueButton.SetActive(false);

            image.SetActive(false);
            mainChar.SetActive(false);
            nextChar.SetActive(false);
            Time.timeScale = 1;

        }
    }
}