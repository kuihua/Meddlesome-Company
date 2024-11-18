using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckExamines : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] correctAnswers;
    public GameObject[] wrongAnswers;

    public GameObject Player;
    public GameObject popupWindow;
    public OpenPopup popupInteract;
    public ActivateCutscene activateCutscene;
    // public Button[] selectedAnswers;
    // public Button[] possibleAnswers;
    // public Button button;
    [Header("Debug Purposes")]
    public int correctAmt;
    public int wrongAmt;

    public int numCorrect;
    public int wrongHidden;
    // public bool clicked;

    public bool solved = false;


    // Start is called before the first frame update
    void Start()
    {
        // button = GetComponent<Button>();   
        correctAmt = correctAnswers.Length;
        wrongAmt = wrongAnswers.Length;

        popupWindow = transform.parent.gameObject;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // if (!clicked && (numCorrect != 0 || numCorrect != correctAmt) && (wrongHidden != 0 || wrongHidden != wrongAmt)) {
        //     numCorrect = 0;
        // }
        // else if (numCorrect == correctAmt && wrongHidden == wrongAmt) {
        //     // done
        //     Debug.Log("all correct");
        // }
        // if (solved) {
        //     Debug.Log("examine complete");
        // }

    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        // check if correct ones are shown
        CheckAnswers();
        DoneExamine();

        if (solved) {
            Debug.Log("examine complete");
            Player.GetComponent<PlayerMovement>().enabled = true;
            popupInteract.gameObject.SetActive(false);
            popupWindow.SetActive(false);
        } else  {
            ResetValues();
        }
    }

    public void CheckAnswers() {
        // if the right answers are shown and the wrong ones hidden, all are correct
        for (int i = 0; i < correctAnswers.Length; i++) {
            if (correctAnswers[i].activeSelf == true) {
                numCorrect++;
                // Debug.Log(numCorrect);
            }
        }

        for (int j = 0; j < wrongAnswers.Length; j++) {
            if (wrongAnswers[j].activeSelf == false) {
                wrongHidden++;
                // Debug.Log(wrongHidden);
            }
        }
        // if (numCorrect == correctAmt && wrongHidden == wrongAmt) {
        //     Debug.Log("examine complete");
        // } else {
        //     ResetValues();
        // }
    }

    bool DoneExamine() {
        if (numCorrect == correctAmt && wrongHidden == wrongAmt) {
            solved = true;
        } else {
            solved = false;
        }
        return solved;
    }

    void ResetValues() {
        numCorrect = 0;
        wrongHidden = 0;
    }

}

