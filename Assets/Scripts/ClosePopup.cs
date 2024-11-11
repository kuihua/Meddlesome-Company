using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePopup : MonoBehaviour, IPointerClickHandler
{
    public GameObject popupWindow;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        popupWindow = transform.parent.gameObject;
        Player = GameObject.Find("Player");
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        // Debug.Log("click");
        Player.GetComponent<PlayerMovement>().enabled = true;
        popupWindow.SetActive(false);
    }

    // to call in cutscenes
    public void ClosePopupWindow(){
        Player.GetComponent<PlayerMovement>().enabled = true;
        popupWindow.SetActive(false);
    }
}
