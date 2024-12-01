using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCut : MonoBehaviour
{
    public GameObject[] wireOrder;
    int step = 0;

    public GameObject failScreen;
    ScreenFader Sf;

    public GameObject closeButton;
    public GameObject finishButton;

    public ActivateCutscene activateCutscene;
    public GameObject popupWindow;
    public GameObject Player;
    public OpenPopup popupInteract;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        if(popupWindow == null) {
            popupWindow = transform.parent.gameObject;
        }
        Player = GameObject.Find("Player");
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void cutWire(GameObject wire) {
        if(wire == wireOrder[step]) {
            step += 1;
            if(step == wireOrder.Length) {
                Debug.Log("wires cut correctly");
                // closeButton.SetActive(false);
                // finishButton.SetActive(true);

                activateCutscene.ActivateCutsceneKey();
                Player.GetComponent<PlayerMovement>().enabled = true;
                popupInteract.gameObject.SetActive(false);
                popupWindow.SetActive(false);
            }
        }
        else {
            Debug.Log("game over");
            StartCoroutine(fail());
        }
    }

    IEnumerator fail() {
        yield return StartCoroutine(Sf.FadeToBlack());
        failScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
