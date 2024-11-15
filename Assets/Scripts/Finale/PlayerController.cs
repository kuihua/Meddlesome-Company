using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public GameObject CurrentPlayer, OtherPlayer;
    GameObject Anthony, Theo;

    CinemachineVirtualCamera Cam;
    ScreenFader Sf;

    public GameObject[] AnthonyInteractions;
    public GameObject[] TheoInteractions;

    public bool canSwitch;

    // Start is called before the first frame update
    void Start()
    {
        Anthony = GameObject.Find("Anthony");
        Theo = GameObject.Find("Theo");
        Cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        CurrentPlayer = Anthony;
        OtherPlayer = Theo;

        CurrentPlayer.GetComponent<PlayerMovement>().enabled = true;
        OtherPlayer.GetComponent<PlayerMovement>().enabled = false;
        CurrentPlayer.GetComponent<SpriteRenderer>().sortingOrder = 1;
        OtherPlayer.GetComponent<SpriteRenderer>().sortingOrder = 0;

        Physics2D.IgnoreCollision(Anthony.GetComponent<BoxCollider2D>(), Theo.GetComponent<BoxCollider2D>(), true);
        canSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && canSwitch) {
            if(CurrentPlayer == Anthony) {
                SwitchTo(Theo);
            }
            else if(CurrentPlayer == Theo) {
                SwitchTo(Anthony);
            }
        }
    }

    void SwitchTo(GameObject newCharacter) {
        CurrentPlayer.GetComponent<PlayerMovement>().Stop();
        CurrentPlayer.GetComponent<PlayerMovement>().enabled = false;
        CurrentPlayer = newCharacter;
        Cam.Follow = CurrentPlayer.transform;
        if(newCharacter == Anthony) {
            OtherPlayer = Theo;
            foreach(GameObject go in TheoInteractions) {
                go.SetActive(false);
            }
            foreach(GameObject go in AnthonyInteractions) {
                go.SetActive(true);
            }
        }
        else if(newCharacter == Theo) {
            OtherPlayer = Anthony;
            foreach(GameObject go in AnthonyInteractions) {
                go.SetActive(false);
            }
            foreach(GameObject go in TheoInteractions) {
                go.SetActive(true);
            }
        }
        CurrentPlayer.GetComponent<SpriteRenderer>().sortingOrder = 1;
        OtherPlayer.GetComponent<SpriteRenderer>().sortingOrder = 0;
        CurrentPlayer.GetComponent<PlayerMovement>().enabled = true;
    }

    public void CanMove(bool canMove) {
        if(!canMove) {
            CurrentPlayer.GetComponent<PlayerMovement>().Stop();
        }
        CurrentPlayer.GetComponent<PlayerMovement>().enabled = canMove;
        canSwitch = canMove;
    }
}
