using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabasePuzzle : MonoBehaviour
{
    public Draggable[] symbols;
    public bool databaseDone;

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
            Debug.Log("database done");
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
