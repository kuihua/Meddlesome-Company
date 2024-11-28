using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardView : MonoBehaviour
{
    public GameObject CaughtScreen;
    ScreenFader Sf;

    // Start is called before the first frame update
    void Start()
    {
        // CaughtScreen = GameObject.Find("Canvas/Caught screen");
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            Debug.Log("seen");
            yield return StartCoroutine(Caught());
        }
    }

    IEnumerator Caught() {
        yield return StartCoroutine(Sf.FadeToBlack());
        CaughtScreen.SetActive(true);
    }
}
