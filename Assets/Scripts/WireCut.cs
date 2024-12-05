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
    public FActivateCutscene fActivateCutscene;
    public GameObject popupWindow;
    public GameObject Player;
    PlayerController controller;
    public OpenPopup popupInteract;
    public FOpenPopup fPopupInteract;

    public bool inFinale;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        if(popupWindow == null) {
            popupWindow = transform.parent.gameObject;
        }
        if(inFinale) {
            controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
        }
        else {
            Player = GameObject.Find("Player");
        }
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

                if(activateCutscene != null)activateCutscene.ActivateCutsceneKey();
                if(fActivateCutscene != null) fActivateCutscene.ActivateCutsceneKey();

                if(Player != null) Player.GetComponent<PlayerMovement>().enabled = true;
                if(controller != null) controller.CanMove(true);

                if(popupInteract != null) popupInteract.gameObject.SetActive(false);
                if (fPopupInteract != null) fPopupInteract.gameObject.SetActive(false);
                popupWindow.SetActive(false);
            }
        }
        else {
            Debug.Log("game over");
            StartCoroutine(fail());
        }
    }

    IEnumerator fail() {
        failScreen.SetActive(true);
        yield return StartCoroutine(Sf.FadeToBlack());
        transform.parent.gameObject.SetActive(false);
        // gameObject.SetActive(false);
    }
}
