using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabFile : MonoBehaviour
{
    public ClickWord[] words;
    // public bool done;
    public GameObject doneButton;

    // Start is called before the first frame update
    void Start()
    {
        // done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(allWordsClicked()) {
            // done = true;
            doneButton.SetActive(true);
        }
    }

    bool allWordsClicked() {
        bool allClicked = true;
        foreach(ClickWord word in words) {
            if(!word.clicked) {
                allClicked = false;
                break;
            }
        }
        return allClicked;
    }
}
