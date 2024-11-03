using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabasePuzzle : MonoBehaviour
{
    public Draggable[] symbols;
    public bool databaseDone;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        databaseDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!databaseDone && allSymbolsCorrect()) {
            databaseDone = true;
            // foreach(Draggable symbol in symbols) {
            //     symbol.enabled = false;
            // }
            // continueButton.SetActive(true);
            Debug.Log("database done");
        }
        else if(databaseDone && !allSymbolsCorrect()) {
            databaseDone = false;
            continueButton.SetActive(false);
        }
        else if(databaseDone && !continueButton.activeSelf) {
            continueButton.SetActive(true);
        }
    }

    bool allSymbolsCorrect() {
        bool allCorrect = true;
        foreach(Draggable symbol in symbols) {
            if(!symbol.inCorrectSlot) {
                allCorrect = false;
                break;
            }
        }
        return allCorrect;
    }
}
