using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class QuestionAnswer : MonoBehaviour
{
    public string question;
    public string answer;
    public bool dailyDouble;
    public Sprite image;
    public AudioClip audio;
    public string dailyDoubleText;
    public GameObject dailyDoubleImage;
    public GameObject questionImage;
    public GameObject answerImage;

    public void OnClick() {

        
        questionImage.GetComponentInChildren<TMP_Text>().text = question;
        answerImage.GetComponentInChildren<TMP_Text>().text = question + "\n\nANSWER: " + answer;
        if (dailyDouble) {
            dailyDoubleImage.SetActive(true);
            dailyDoubleImage.GetComponent<Image>().sprite = image;
            dailyDoubleImage.GetComponentInChildren<AudioSource>().clip = audio;
            dailyDoubleImage.GetComponentInChildren<AudioSource>().Play();
            dailyDoubleImage.GetComponentInChildren<TMP_Text>().text = dailyDoubleText;
            StartCoroutine(WaitCoroutine());
        }
        else {
            questionImage.SetActive(true);
        }
        answerImage.SetActive(true);
        
        questionImage.transform.localPosition = this.transform.localPosition;
        dailyDoubleImage.transform.localPosition = this.transform.localPosition;
    }

    IEnumerator WaitCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        questionImage.SetActive(true);
    }
}
