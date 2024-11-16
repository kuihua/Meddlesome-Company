using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckExamines : MonoBehaviour, IPointerClickHandler
{
    public Button[] correctAnswers;
    // public Button[] selectedAnswers;
    // public Button[] possibleAnswers;
    public Button button;
    public int correct;
    public int numCorrect;
    public bool clicked;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();   
        correct = correctAnswers.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!clicked && (numCorrect != 0 || numCorrect != correct)) {
            numCorrect = 0;
        }
        else if (numCorrect == correct) {
            // done
            Debug.Log("all correct");
        }
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = true;
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            if (correctAnswers[i].enabled == true) {
                numCorrect++;
                Debug.Log(numCorrect);
            }
        }
        clicked = false;
    }
}
