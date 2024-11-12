using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireLever : MonoBehaviour, IDragHandler
{
    public Transform start, end;
    public OpenPopup popupInteract;
    GameObject popupWindow;
    GameObject Player;

    bool pulled;
    float timer;

    public ActivateCutscene activateCutscene;

    // Start is called before the first frame update
    void Start()
    {
        popupWindow = transform.parent.gameObject;
        Player = GameObject.Find("Player");
        pulled = false;
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(pulled) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                Player.GetComponent<PlayerMovement>().enabled = true;
                popupInteract.gameObject.SetActive(false);
                popupWindow.SetActive(false);
                if(activateCutscene != null) {
                    activateCutscene.ActivateCutsceneKey();
                }
            }
        }
        else if(transform.position.y <= end.position.y) {
            pulled = true;
            // print("fire alarm pulled");
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if(!pulled) {
            float yPos;
            if(Input.mousePosition.y > start.position.y) {
                yPos = start.position.y;
            }
            else if(Input.mousePosition.y < end.position.y) {
                yPos = end.position.y;
            }
            else {
                yPos = Input.mousePosition.y;
            }
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
}
