using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.IO;
using System.Text;

public class GameControl : MonoBehaviour
{
    // [Serializable]
    // private Text questionTextElement;
    // [Serializable]
    // private Button[] buttons;
    // [Serializable]
    // private Question[] questions;
    public GameObject Question;
    public GameObject Category;
    public GameObject MainCanvas;


    // Start is called before the first frame update
    void Start()
    {

        StreamReader sr = new StreamReader("Assets\\TextFiles\\Questions.txt");

        if (Display.displays.Length > 1)
        {
            // Activate the display 1 (second monitor connected to the system).
            Display.displays[1].Activate();
        }

        float xPosition = -787.5f;
        for (int i = 0; i < 6; i++) {
            float yPosition = 455f;
            // Add Category text
            makeCategory(xPosition, yPosition, sr.ReadLine());
            yPosition -= 170f;
            for(int j = 0; j < 5; j++) {
                var questionAnswer = sr.ReadLine().Split(';');
                makeButton(xPosition, yPosition, "$" + (200 * (j + 1)), questionAnswer[0], questionAnswer[1], bool.Parse(questionAnswer[2]), questionAnswer[3], questionAnswer[4]);
                yPosition -= 180f;
            }
            xPosition += 315f;
        }
    }

    private void Awake() {
        Question = GameObject.Find("Question");
        Category = GameObject.Find("Category");
        MainCanvas = GameObject.Find("MainCanvas");
    }

    public void makeButton(float x, float y, string text, string question, string answer, bool dailyDouble, string imageName, string dailyDoubleText) {
        var tempA = Instantiate(Question);
        tempA.GetComponentInChildren<TMP_Text>().text = text;
        tempA.GetComponent<QuestionAnswer>().question = question;
        tempA.GetComponent<QuestionAnswer>().answer = answer;
        tempA.GetComponent<QuestionAnswer>().dailyDouble = dailyDouble;
        if (dailyDouble) {
            tempA.GetComponent<QuestionAnswer>().image = Resources.Load<Sprite>(imageName);
            tempA.GetComponent<QuestionAnswer>().dailyDoubleText = dailyDoubleText;
            tempA.GetComponent<QuestionAnswer>().audio = Resources.Load<AudioClip>(imageName + "mp3");
        }
        tempA.transform.SetParent(MainCanvas.transform, false);
        RectTransform transformTempA = tempA.gameObject.GetComponent<RectTransform>();
        Vector2 positionA = transformTempA.anchoredPosition;
        transformTempA.anchoredPosition = new Vector2(x, y);
    }

    public void makeCategory(float x, float y, string text) {
        var temp = Instantiate(Category);
        temp.GetComponentInChildren<TMP_Text>().text = text;
        temp.transform.SetParent(MainCanvas.transform, false);
        RectTransform transformTemp = temp.gameObject.GetComponent<RectTransform>();
        Vector2 position = transformTemp.anchoredPosition;
        transformTemp.anchoredPosition = new Vector2(x, y);
    }




}

// [Serializable]
// public class Question
// {
//     public string questions[];
//     public string answers[];
//     public bool isRead;
// }