using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FFinishPuzzle : MonoBehaviour, IPointerClickHandler
{
    public GameObject popupWindow;
    public FOpenPopup popupInteract;
    [Header("Has cutscene after?")]
    public FActivateCutscene activateCutscene;
    public bool hasCutsceneAfter;

    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        if(popupWindow == null) {
            popupWindow = transform.parent.gameObject;
        }
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        controller.CanMove(true);
        popupInteract.gameObject.SetActive(false);
        popupWindow.SetActive(false);
        if (hasCutsceneAfter) {
            activateCutscene.ActivateCutsceneKey();
        }
    } 
}
