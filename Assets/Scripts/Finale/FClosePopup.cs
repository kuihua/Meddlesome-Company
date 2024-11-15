using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FClosePopup : MonoBehaviour, IPointerClickHandler
{
    GameObject popupWindow;
    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        popupWindow = transform.parent.gameObject;
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        controller.CanMove(true);
        popupWindow.SetActive(false);
    }
}
