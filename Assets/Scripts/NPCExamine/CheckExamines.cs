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

    private GameObject Player;
    private GameObject popupWindow;
    public ActivateCutscene activateCutscene;
    public GameObject dialogueUI;

    // [Header("Debug Purposes")]
    private int correctAmt;
    private int wrongAmt;

    private int numCorrect;
    private int wrongHidden;

    public bool solved = false;
    public bool hasCutsceneAfter;
    public NPCDialogue npcDialogue;



    // Start is called before the first frame update
    void Start()
    {
        // button = GetComponent<Button>();   
        correctAmt = correctAnswers.Length;
        wrongAmt = wrongAnswers.Length;
// 
        // popupWindow = transform.parent.gameObject;
        if(popupWindow == null) {
            popupWindow = transform.parent.gameObject;
        }
        Player = GameObject.Find("Player");
        // dialogueUI = GameObject.Find("DialogueUI");
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        // check if correct ones are shown
        CheckAnswers();
        DoneExamine();

        if (solved && dialogueUI.activeSelf == false) {
            // Debug.Log("examine complete");
            popupWindow.gameObject.SetActive(false);
            Player.GetComponent<PlayerMovement>().enabled = true;
            if (hasCutsceneAfter) {
                activateCutscene.ActivateCutsceneKey();
            } else {
                Debug.Log("you forgot to put a cutscene here");
            }
            
        } else  {
            npcDialogue.activateNPCExamineDialogue();
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

