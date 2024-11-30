using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardView : MonoBehaviour
{
    public GameObject CaughtScreen;
    ScreenFader Sf;
    // bool caught = false;

    // Start is called before the first frame update
    void Start()
    {
        // CaughtScreen = GameObject.Find("Canvas/Caught screen");
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(caught && Input.GetKeyDown(KeyCode.E)) {
    //         CaughtScreen.SetActive(true);
    //     }
    // }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            Debug.Log("seen");
            // caught = true;
            yield return StartCoroutine(Caught());
        }
    }

    IEnumerator Caught() {
        CaughtScreen.SetActive(true);
        yield return StartCoroutine(Sf.FadeToBlack());
        // CaughtScreen.SetActive(true);
    }
}
